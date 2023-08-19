// See https://aka.ms/new-console-template for more information

var demo = new InmutableDemo();


Console.WriteLine($"String: {demo.GetString("beto")}");

Console.Read();



class InmutableDemo {
    public string GetString(string value) {
        return value += value + " help!";
    }
}
