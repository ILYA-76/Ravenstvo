using System;
using System.Text.RegularExpressions;
String s = $"Acer H223HQ [22\" LCD] (LF6080384200)";

Regex regex = new Regex(@"(?=\w)[\d]+[.,]?[\d]+(?=\W{2})");
Match match = regex.Match(s);

String x = match.Value;

Console.WriteLine($"Изначальная строка: {s}");
Console.WriteLine($"Диагональ монитора: {x}");
