// Single Responsibility Principle

using System;

// BAD APPROACH: One class handles multiple responsibilities
public class SimpleReportSaverBad
{
    public void Save(string data, string format)
    {
        switch (format.ToUpper())
        {
            case "TXT":
                Console.WriteLine("Saving text: " + data);
                break;

            case "PDF":
                Console.WriteLine("Saving PDF: " + data);
                break;

            default:
                Console.WriteLine("Unsupported format!");
                break;
        }
    }
}

// GOOD APPROACH: Each class has one responsibility

// Step 1: Create a common contract
public interface ISaver
{
    void Save(string data);
}

// Step 2: TXT saving responsibility
public class TxtSaver : ISaver
{
    public void Save(string data)
    {
        Console.WriteLine("Saving TXT: " + data);
    }
}

// Step 3: PDF saving responsibility
public class PdfSaver : ISaver
{
    public void Save(string data)
    {
        Console.WriteLine("Saving PDF: " + data);
    }
}

// Step 4: JSON saving responsibility
public class JsonSaver : ISaver
{
    public void Save(string data)
    {
        Console.WriteLine("Saving JSON: " + data);
    }
}

// Main Program
public class Program
{
    public static void Main()
    {
        string report = "Monthly Sales Report";

        Console.WriteLine("BAD APPROACH");

        SimpleReportSaverBad badSaver = new SimpleReportSaverBad();

        badSaver.Save(report, "TXT");
        badSaver.Save(report, "PDF");

        Console.WriteLine();

        Console.WriteLine("GOOD APPROACH (SRP)");

        ISaver txtSaver = new TxtSaver();
        ISaver pdfSaver = new PdfSaver();
        ISaver jsonSaver = new JsonSaver();

        txtSaver.Save(report);
        pdfSaver.Save(report);
        jsonSaver.Save(report);
    }
}
