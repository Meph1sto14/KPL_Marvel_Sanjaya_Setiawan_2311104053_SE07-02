class SimpleDataBase<T>
{
    private List<T> storedData = new List<T>();
    private List<DateTime> inputDates = new List<DateTime>();

    public void AddNewData(T item)
    {
        storedData.Add(item);
        inputDates.Add(DateTime.UtcNow);
    }

    public void PrintAllData()
    {
        for (int i = 0; i < storedData.Count; i++)
        {
            Console.WriteLine($"Data {i+1} berisi: {storedData[i]}, yang disimpan pada waktu UTC: {inputDates[i]}");
        }
    }
}
