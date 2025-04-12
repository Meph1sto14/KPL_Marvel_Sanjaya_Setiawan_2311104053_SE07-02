using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select language: en / id");
        string langInput = Console.ReadLine()?.Trim().ToLower();
        bool isEnglish = langInput == "en";

        BankTransferConfig config = BankTransferConfig.LoadConfig();

        config.Lang = isEnglish ? "en" : "id";

        Console.WriteLine(isEnglish
            ? "Please insert the amount of money to transfer:"
            : "Masukkan jumlah uang yang akan di-transfer:");
        int amount = int.Parse(Console.ReadLine());

        int fee = (amount <= config.Transfer.Threshold)
            ? config.Transfer.LowFee
            : config.Transfer.HighFee;

        int total = amount + fee;

        Console.WriteLine(isEnglish
            ? $"Transfer fee = {fee}"
            : $"Biaya transfer = {fee}");
        Console.WriteLine(isEnglish
            ? $"Total amount = {total}"
            : $"Total jumlah = {total}");

        Console.WriteLine(isEnglish ? "Transfer Methods:" : "Metode Transfer:");
        for (int i = 0; i < config.Methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.Methods[i]}");
        }

        string transferPrompt = isEnglish ? "Select transfer method: " : "Pilih jenis transfer: ";
        Console.Write($"{transferPrompt}");
        string methodChoice = Console.ReadLine();

        Console.WriteLine(isEnglish
            ? $"Are you sure you want to transfer? ({config.Confirmation.En}/{(config.Confirmation.En == "yes" ? "no" : "no")})"
            : $"Apakah anda yakin ingin mentransfer? ({config.Confirmation.Id}/{(config.Confirmation.Id == "ya" ? "tidak" : "tidak")})");

        string confirmation = Console.ReadLine()?.Trim().ToLower();

        bool isConfirmed = isEnglish
            ? confirmation == config.Confirmation.En
            : confirmation == config.Confirmation.Id;

        if (isConfirmed)
        {
            Console.WriteLine(isEnglish ? "Transfer is completed." : "Proses transfer berhasil.");
        }
        else
        {
            Console.WriteLine(isEnglish ? "Transfer is cancelled." : "Transfer dibatalkan.");
        }
    }
}