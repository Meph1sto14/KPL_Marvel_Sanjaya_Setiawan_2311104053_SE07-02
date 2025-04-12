using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class BankTransferConfig
{
    public string Lang { get; set; }
    public Transfer Transfer { get; set; }
    public List<string> Methods { get; set; }
    public Confirmation Confirmation { get; set; }

    private const string configFilePath = "bank_transfer_config.json";

    public static BankTransferConfig LoadConfig()
    {
        try
        {
            if (File.Exists(configFilePath))
            {
                string jsonString = File.ReadAllText(configFilePath);
                return JsonConvert.DeserializeObject<BankTransferConfig>(jsonString);
            }
            else
            {
                var defaultConfig = GetDefault();
                defaultConfig.SaveConfig();
                return defaultConfig;
            }
        }
        catch
        {
            return GetDefault();
        }
    }

    public static BankTransferConfig GetDefault()
    {
        return new BankTransferConfig
        {
            Lang = "en",
            Transfer = new Transfer { Threshold = 25000000, LowFee = 6500, HighFee = 15000 },
            Methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" },
            Confirmation = new Confirmation { En = "yes", Id = "ya" }
        };
    }

    public void SaveConfig()
    {
        string json = JsonConvert.SerializeObject(this, Formatting.Indented);
        File.WriteAllText(configFilePath, json);
    }
}

public class Transfer
{
    public int Threshold { get; set; }
    public int LowFee { get; set; }
    public int HighFee { get; set; }
}

public class Confirmation
{
    public string En { get; set; }
    public string Id { get; set; }
}