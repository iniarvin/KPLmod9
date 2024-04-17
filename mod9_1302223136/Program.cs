// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Text.Json;

internal class tpmodul8_1302223136
{
    private static void Main(string[] args)
    {
        int uang;
        int biayatf;
        int total;
        String bahasa;
        ConfigWrite A = new ConfigWrite();


        Console.WriteLine("Pilih bahasa Indonesia: id");
        Console.WriteLine("Select English language: en");
        bahasa = Console.ReadLine();

        if (bahasa == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer");
            uang = Convert.ToInt32(Console.ReadLine());
            if (uang <= A.config.threshold)
            {
                biayatf = A.config.low_fee;
                total = uang + biayatf;
                Console.WriteLine("Transfer fee = " + total);
            }
            else if (uang > A.config.threshold)
            {
                biayatf = A.config.high_fee;
                total = uang + biayatf;
                Console.WriteLine("Transfer fee = " + total);
            }
        }
        else if(bahasa == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akaan ditransfer");
            uang = Convert.ToInt32(Console.ReadLine());
            if (uang <= A.config.threshold)
            {
                biayatf = A.config.low_fee;
                total = uang + biayatf;
                Console.WriteLine("Biaya transfer = " + total);
            }
            else if(uang > A.config.threshold)
            {
                biayatf = A.config.high_fee;
                total = uang + biayatf;
                Console.WriteLine("Biaya transfer = " + total);
            }

        }

    }
}

public class BankTransferConfig
{
    public String language { get; set; }
    public int threshold { get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set; }
    public BankTransferConfig() { }

    public BankTransferConfig(String language, int threshold, int low_fee, int high_fee)
    {
        this.language = language;
        this.threshold = threshold;
        this.low_fee = low_fee;
        this.high_fee = high_fee;
    }
}

public class ConfigWrite
{
    public BankTransferConfig config;
    public const String filePath = @"bank_transfer_config.json";
    public ConfigWrite() {
        try
        {
            ReadConfigFile();
        }
        catch(Exception e)
        {
            SetDefault();
            WriteNewConfigFile();
        }
        
    }
    private BankTransferConfig ReadConfigFile()
    {
        string jsonData = File.ReadAllText(filePath);
        config = JsonSerializer.Deserialize<BankTransferConfig>(jsonData);
        return config;
    }
    private void SetDefault()
    {
        config = new BankTransferConfig("en", 25000000, 6500, 1200);
    }
    private void WriteNewConfigFile()
    {
        JsonSerializerOptions opts = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        string JsonString = JsonSerializer.Serialize(config, opts);
        File.WriteAllText(filePath, JsonString);
    }
}
