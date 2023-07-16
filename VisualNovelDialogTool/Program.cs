using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;


//SetKey() fonksiyonu, verilen json içindeki diyalog numaralarını increaseValue kadar arttırır.
void SetKey()
{
    int increaseValue = 14;
    string lastString = "{";
    string json = File.ReadAllText("C:\\Users\\ASUS\\Desktop\\Dialogs.json");
    JObject jsonObject = JObject.Parse(json);

    foreach (var item in jsonObject)
    {
        Console.WriteLine(item.Key);
        lastString += $"\"{int.Parse(item.Key) + increaseValue}\": {item.Value},\n";
    }

    lastString += "}";
    File.WriteAllText("C:\\Users\\ASUS\\Desktop\\Dialogs.json", lastString);
}

//SetKey() ile düzenlenen json dosyasını yatay bir şekilde düzenlemek için SetKey() ardından bu fonksiyon çalıştırılır.
void EditSerialize()
{
    string lastString = "{";
    string formattedJson = "";
    string json = File.ReadAllText("C:\\Users\\ASUS\\Desktop\\Dialogs.json");
    JObject jsonObject = JObject.Parse(json);

    for (int i = 802; i < 810; i++) //en sonki diyalog numarasından bir fazlasını yazıyoruz sınır olarak
    {
        JToken itemToken = jsonObject[i.ToString()];
        formattedJson = itemToken.ToString(Formatting.None);
        formattedJson = formattedJson.Replace(Environment.NewLine, "");

        lastString += $"\"{i}\": {formattedJson},\n";
    }
    lastString += "}";
    string updatedJson = lastString.ToString();
    File.WriteAllText("C:\\Users\\ASUS\\Desktop\\Dialogs.json", updatedJson);
}

//girilen virgül ile sıralı int değerlerinden limitten büyük olanları addedAmount kadar arttırır ve konsola yazar.
void EditNumberArray()
{
    string numbers = "5,10,15,20,25,30";
    string[] array = numbers.Split(',');
    int limit = 20;
    int addedAmount = 1;
    string editedNumbers = "";

    foreach (var item in array)
    {
        var value = int.Parse(item);
        if (value > limit)
        {
            value = value + addedAmount;
        }
        editedNumbers += value.ToString() + ",";
    }

    Console.WriteLine(editedNumbers);
}

EditNumberArray();