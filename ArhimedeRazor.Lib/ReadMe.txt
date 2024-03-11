For named httpclient , add the following code in the Program.cs file
builder.Services.AddHttpClient(HttpClientType.OdataClient, client => client.BaseAddress = new Uri(YOUR URL));
