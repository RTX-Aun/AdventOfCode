namespace AdventOfCode.Utilities.File
{
    using System;

    public static class File
    {
        public static T[] ConvertToArray<T>(string path, Func<string, T> convert)
        {
            var array = Array.Empty<T>();
            try
            {
                var lines = System.IO.File.ReadAllLines(path);
                array = new T[lines.Length];
                for (var i = 0; i < lines.Length; i++)
                {
                    array[i] = convert(lines[i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return array;
        }
    }
}