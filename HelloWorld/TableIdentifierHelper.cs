using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    class TableIdentifierHelper
    {
        public const char OpenBracket = '[';
        public const char CloseBracket = ']';
        public const char Dot = '.';
        public const char DoubleQuotation = '"';

        #region Deal with Sql Table Identifier

        /// <summary>
        /// Splite table name. The table may include DbName.SchemaName.TableName.
        /// </summary>
        /// <param name="tableName">table name specified by user.</param>
        /// <returns></returns>
        public static string[] SplitIdentifierForSql(string tableName)
        {
            return SplitIdentifier(tableName);
        }

        public static string[] SplitIdentifier(string tableName, char quotePrefix = OpenBracket, char quoteSuffix = CloseBracket, char identifierSeparator = Dot)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException("tableName");
            }

            List<string> items = new List<string>();
            int closeBracketCount = 0;

            int startIndex = 0;
            int length = 0;

            int i = 0;

            while (i < tableName.Length)
            {
                if (tableName[i] == quotePrefix)
                {
                    ++i;
                    while (i < tableName.Length)
                    {
                        if (tableName[i] == quoteSuffix)
                        {
                            ++closeBracketCount;
                        }
                        else if (tableName[i] == Dot && i - 1 >= 0 && tableName[i - 1] == quoteSuffix && closeBracketCount % 2 == 1)
                        {
                            length = i - startIndex;
                            items.Add(tableName.Substring(startIndex, length));
                            startIndex = ++i;
                            break;
                        }
                        ++i;
                    }
                }
                else if (tableName[i] == identifierSeparator)
                {
                    items.Add(tableName.Substring(startIndex, i - startIndex));
                    startIndex = ++i;
                }
                else
                {
                    i++;
                }
            }

            if (startIndex != tableName.Length)
            {
                items.Add(tableName.Substring(startIndex, tableName.Length - startIndex));
            }

            return items.ToArray();
        }

        public static string[] SplitIdentifierForSqlUnquoted(string tableName)
        {
            var arr = SplitIdentifierForSql(tableName);
            if (arr != null && arr.Length >= 1)
            {
                using (var sqlCommandBuilder = new SqlCommandBuilder())
                {
                    return arr.Select(s => sqlCommandBuilder.UnquoteIdentifier(s)).ToArray();
                }
            }
            return null;
        }

        #endregion

        #region Deal with Oracle Table Identifier

        /// <summary>
        /// Split Oracle identifier.
        /// Table name goes like "schema"."table", schema."table", table or "table".
        /// Column name may goes like "schema"."table"."column",  schema."table"."column", "table"."column", "table".column, "column", column etc.
        /// https://docs.oracle.com/cd/B19306_01/server.102/b14200/sql_elements008.htm
        /// </summary>
        public static string[] SplitIdentifierForOracle(string tableName)
        {
            try
            {
                return SplitIdentifierWithSingleQuote(tableName, DoubleQuotation);
            }
            catch (ArgumentException)
            {
                return null;
                //throw new HybridDeliveryException(string.Format(CultureInfo.CurrentCulture, Resources.UserErrorInvalidOracleIdentifier, tableName),
                //                                  HybridDeliveryExceptionCode.UserErrorFailedToParseOracleIdentifier);
            }
        }

        #endregion
        private static string[] SplitIdentifierWithSingleQuote(string name, char quote)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }

            List<string> items = new List<string>();
            bool waitingForClosedQutation = false;
            bool invalidIdentifierDetected = false;
            int startIndex = 0;
            int length = 0;
            int i = 0;

            while (i < name.Length)
            {
                if (name[i] == quote)
                {
                    // new identfier start but without preceding Dot
                    if (waitingForClosedQutation == false && i > 0 && name[i - 1] != Dot)
                    {
                        invalidIdentifierDetected = true;
                        break;
                    }

                    // find an identifer, but the length is zero or the following text is invalid
                    if (waitingForClosedQutation == true && (length == 0 || (i + 1 < name.Length && name[i + 1] != Dot)))
                    {
                        invalidIdentifierDetected = true;
                        break;
                    }

                    //find one identifier
                    if (waitingForClosedQutation)
                    {
                        items.Add(name.Substring(startIndex, length));
                    }

                    waitingForClosedQutation = !waitingForClosedQutation;
                    i += 1;
                    startIndex = i;
                    length = 0;
                }
                else if (name[i] == Dot)
                {
                    if (waitingForClosedQutation == false && (i == 0 || i == name.Length - 1))
                    {
                        invalidIdentifierDetected = true;
                        break;
                    }

                    if (waitingForClosedQutation == true)
                    {
                        i += 1;
                        length += 1;
                    }
                    else
                    {
                        if (name[i - 1] != quote)
                        {
                            if (length > 0)
                            {
                                items.Add(name.Substring(startIndex, length));
                            }
                            else
                            {
                                invalidIdentifierDetected = true;
                                break;
                            }
                        }

                        i += 1;
                        startIndex = i;
                        length = 0;
                    }
                }
                else
                {
                    i += 1;
                    length += 1;
                }
            }

            if (waitingForClosedQutation || invalidIdentifierDetected)
            {
                throw new ArgumentException("input name is invalid.");
            }

            if (startIndex != name.Length && length > 0)
            {
                items.Add(name.Substring(startIndex, length));
            }

            return items.ToArray();
        }

    }
}
