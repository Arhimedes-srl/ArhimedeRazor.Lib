### Using Syncfusion Blazor Components
1. If you do not have a syncfusion license already, you can get one from here for free by clicking [HERE](https://www.syncfusion.com/products/communitylicense)
2. Setup Syncfusion in your project using [this documentation](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
3. Syncfusion version used is *24.1.41*
4. Create a page and use the components :
   ```
   @page "/dropdownexample"
   @using ArhimedeRazor.Lib
   @rendermode InteractiveWebAssembly
   <h3>DropDown Example</h3>

   <ArDropDown TItem="Person" TValue="int"
               @bind-Value="SelectedPersonId" ComboText="Name"
               ComboValue="Id" PlaceHolder="Select person" DataSource="@people"></ArDropDown>
   
   <h3>@(people.Where(x=>x.Id == SelectedPersonId).Select(x=>x.Name).FirstOrDefault())</h3>
   @code {
       private int SelectedPersonId { get; set; }
       private List<Person> people = new List<Person>
       {
           new Person {Id =1 , Name = "Andrei", Age = 30 },
           new Person {Id =2 , Name = "Mihai", Age = 25 },
           new Person {Id =3 , Name = "Ion", Age = 40 },
           new Person {Id =4 , Name = "Vasile", Age = 35 }
       };
       protected override async Task OnInitializedAsync()
       {
        
       }
       public class Person
       { 
           public int Id { get; set; }
           public string Name { get; set; }
           public int Age { get; set; }

       }
   }

   ```
