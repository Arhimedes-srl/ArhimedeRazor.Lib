using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace ArhimedeRazor.Lib.Helpers;

public class Dynamic 
{
    //function that gets property value of T object
    public T GetPropertyValue<T>(string propertyName,T obj)
    {
        var property = obj.GetType().GetProperty(propertyName);
        return (T)property.GetValue(obj);
    }
    public bool EqualsDefaultValue<T>(T value)
    {
        return EqualityComparer<T>.Default.Equals(value, default(T));
    }
    public readonly Dictionary<string, string> _properties = new();
    //DateTime to string
    public string DateTimeToString(DateTime dateTime)
    {
        return dateTime.ToString("yyyy-MM-dd HH!mm!ss");
    }
    public DateTime StringToDateTime(string dateTime)
    {
        return DateTime.Parse(dateTime.Replace("!",":"));
    }
    public bool CanParse(string value,out DateTime result)
    {
        return DateTime.TryParse(value.Replace("!", ":"), out result);
    }
    //list to string
    public string DatasourceToString(List<string> list,string selectedValue)
    {
        var listString = $"{selectedValue}//";
        foreach (var item in list)
        {
            listString += $"{item}|";
        }
        listString = listString.TrimEnd('|');
        return listString;
    }
    //string to datasource including the selected value returned
    public (List<string>, string) StringToDatasource(string listString)
    {
        var list = new List<string>();
        var selectedValue = listString.Split("//")[0];
        var items = listString.Split("//")[1].Split('|');
        foreach (var item in items)
        {
            list.Add(item);
        }
        return (list, selectedValue);
    }

    public void ParsePropsToDictionary(string propsCollection)
    {
        var props = propsCollection.Split(';');
        foreach (var prop in props)
        {
            var key = prop.Split(':')[0];
            var value = prop.Split(':')[1];
            AddProperty(key, value);
        }
    }
    public string DictionaryToString(Dictionary<string,string> props)
    {
        var propsCollection = "";
        foreach (var prop in props)
        {
            propsCollection += $"{prop.Key}:{prop.Value};";
        }
        propsCollection = propsCollection.TrimEnd(';');
        return propsCollection;
    }
    public string this[string propertyName]
    {
        get => _properties[propertyName];
        set => AddProperty(propertyName,value);
    }
    
    public void AddProperty(string name, string value)
    {
        _properties[name] = value;

    }
}
