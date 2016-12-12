using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ProductList.Models;

namespace ProductListClient
{
    class Client
    {
        static async Task GetsAsync()                         // async methods return Task or Task<T>
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://webinventorybm.azurewebsites.net/");          // base URL for API Controller i.e. RESTFul service

                    // add an Accept header for JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            // or application/xml

                    // GET ../products/all
                    HttpResponseMessage response = await client.GetAsync("/products/all");              // async call, await suspends until task finished            
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read results 
                        var products = await response.Content.ReadAsAsync<IEnumerable<Product>>();
                        foreach (var product in products)
                        {
                            Console.WriteLine(product.ProductCode+" "+product.ProductName+" " +product.Category+" "+product.Unit+" "+product.ProductPrice);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }
                    Console.WriteLine();

                    // get product by product code, you can use a keyword, retrieve products containing the keyword
                    // GET ../products/productCode/gf250 or only gf 
                    response = await client.GetAsync("/products/productCode/gf250");
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read results 
                        var product = await response.Content.ReadAsAsync<IEnumerable<Product>>();
                        foreach (var p in product)
                        {
                            Console.WriteLine(p.ProductCode + " " + p.ProductName + " " + p.Category + " " + p.Unit + " " + p.ProductPrice);
                        }                       
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    Console.WriteLine();

                    // get products in specified category
                    // GET ../products/category/electrical  or just "elect" 
                    response = await client.GetAsync("/products/category/electrical");
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read results 
                        var products = await response.Content.ReadAsAsync<IEnumerable<Product>>();
                        foreach (var product in products)
                        {
                            Console.WriteLine(product.ProductCode + " " + product.ProductName + " " + product.Category + " " + product.Unit + " " + product.ProductPrice);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    Console.WriteLine();

                    // GET ../products/productName/keyword
                    // get products which contain a keyword in their name
                    response = await client.GetAsync("/products/productName?keyword=cable");
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read results 
                        var products = await response.Content.ReadAsAsync<IEnumerable<Product>>();
                        foreach (var product in products)
                        {
                            Console.WriteLine(product.ProductCode + " " + product.ProductName + " " + product.Category + " " + product.Unit + " " + product.ProductPrice);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        

        // kick off
        static void Main()
        {          
            GetsAsync().Wait();
            Console.ReadLine();
        }


    }
}
