using System;
using System.IO;
using System.Text.Json;

public class CovidConfig
{
    public string satuan_suhu { get; set; }
    public int batas_hari_demam { get; set; }
    public string pesan_ditolak { get; set; }
    public string pesan_diterima { get; set; }

    public CovidConfig()
    {
        satuan_suhu = "celcius";
        batas_hari_demam = 14;
        pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
    }

    public static CovidConfig LoadFromFile(string path = "covid_config.json")
    {
        CovidConfig config;
        if (File.Exists(path))
        {
            try
            {
                string json = File.ReadAllText(path);
                config = JsonSerializer.Deserialize<CovidConfig>(json) ?? new CovidConfig();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing file JSON '{path}': {ex.Message}. Menggunakan konfigurasi default.");
                config = new CovidConfig();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error membaca file '{path}': {ex.Message}. Menggunakan konfigurasi default.");
                config = new CovidConfig();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error tidak terduga saat memuat konfigurasi: {ex.Message}. Menggunakan konfigurasi default.");
                config = new CovidConfig();
            }
        }
        else
        {
            Console.WriteLine($"File konfigurasi '{path}' tidak ditemukan. Menggunakan konfigurasi default.");
            config = new CovidConfig();
        }
        return config;
    }

    public void UbahSatuan()
    {
        if (string.Equals(satuan_suhu, "celcius", StringComparison.OrdinalIgnoreCase))
            satuan_suhu = "fahrenheit";
        else
            satuan_suhu = "celcius";
    }

    public void SaveToFile(string path = "covid_config.json")
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(path, json);
            Console.WriteLine($"Konfigurasi berhasil disimpan ke '{path}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error menyimpan konfigurasi ke file '{path}': {ex.Message}");
        }
    }
}