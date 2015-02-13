using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSV_RealEstate
{
    // WHERE TO START?
    // 1. Complete the RealEstateType enumeration
    // 2. Complete the RealEstateSale object.  Fill in all properties, then create the constructor.
    // 3. Complete the GetRealEstateSaleList() function.  This is the function that actually reads in the .csv document and extracts a single row from the document and passes it into the RealEstateSale constructor to create a list of RealEstateSale Objects.
    // 4. Start by displaying the the information in the Main() function by creating lambda expressions.  After you have acheived your desired output, then translate your logic into the function for testing.
    class Program
    {
        static void Main(string[] args)
        {
            List<RealEstateSale> realEstateSaleList = GetRealEstateSaleList();
            
            //Display the average square footage of a Condo sold in the city of Sacramento, 
            //Use the GetAverageSquareFootageByRealEstateTypeAndCity() function.
            Console.WriteLine("average square footage of a Condo sold in the city of Sacramento: " + GetAverageSquareFootageByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Condo, "Sacramento"));
            //Display the total sales of all residential homes in Elk Grove.  Use the GetTotalSalesByRealEstateTypeAndCity() function for testing.
            Console.WriteLine("total sales of all residential homes in Elk Grove: " + GetTotalSalesByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Residential, "Elk Grove"));
            //Display the total number of residential homes sold in the zip code 95842.  Use the GetNumberOfSalesByRealEstateTypeAndZip() function for testing.
            Console.WriteLine("total number of residential homes sold in the zip code 95842: " + GetNumberOfSalesByRealEstateTypeAndZip(realEstateSaleList, RealEstateType.Residential, "95842"));
            //Display the average sale price of a lot in Sacramento.  Use the GetAverageSalePriceByRealEstateTypeAndCity() function for testing.
            Console.WriteLine("average sale price of a lot in Sacramento: " + GetAverageSalePriceByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Lot, "Sacramento"));
            //Display the average price per square foot for a condo in Sacramento. Round to 2 decimal places. Use the GetAveragePricePerSquareFootByRealEstateTypeAndCity() function for testing.
            Console.WriteLine("average price per square foot for a condo in Sacramento: " + GetAveragePricePerSquareFootByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Residential, "Sacramento"));
            //Display the number of all sales that were completed on a Wednesday.  Use the GetNumberOfSalesByDayOfWeek() function for testing.
            Console.WriteLine("number of all sales that were completed on a Wednesday: " + GetNumberOfSalesByDayOfWeek(realEstateSaleList, DayOfWeek.Wednesday));
            //Display the average number of bedrooms for a residential home in Sacramento when the 
            // price is greater than 300000.  Round to 2 decimal places.  Use the GetAverageBedsByRealEstateTypeAndCityHigherThanPrice() function for testing.
            Console.WriteLine("average number of bedrooms for a residential home in Sacramento when the price is greater than 300000: " + GetAverageBedsByRealEstateTypeAndCityHigherThanPrice(realEstateSaleList, RealEstateType.Residential, "Sacramento", 300000));
            //Extra Credit:
            //Display top 5 cities by the number of homes sold (using the GroupBy extension)
            // Use the GetTop5CitiesByNumberOfHomesSold() function for testing.
            Console.WriteLine("top 5 cities by the number of homes sold: " + string.Join(",", GetTop5CitiesByNumberOfHomesSold(realEstateSaleList)));

            Console.ReadKey();
        }
        public static List<RealEstateSale> GetRealEstateSaleList()
        {
            //read in the realestatedata.csv file.  As you process each row, you'll add a new 
            // RealEstateData object to the list for each row of the document, excluding the first.  bool skipFirstLine = true;
                List<RealEstateSale> RealEstateData = new List<RealEstateSale>();
                using (StreamReader reader = new StreamReader("realestatedata.csv"))
                {
                    // Get and don't use the first line
                    string firstline = reader.ReadLine();
                    // Loop through the rest of the lines
                    while (!reader.EndOfStream)
                    {
                        // Adds new string to our list
                        RealEstateData.Add(new RealEstateSale(reader.ReadLine()));
                    }
                }
                return RealEstateData;
        }

        public static double GetAverageSquareFootageByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city) 
        {
            return realEstateDataList.Where(x => x.City.ToLower() == city.ToLower() && x.RealEstateType == realEstateType).Average(x => x.Footage);
        }

        public static decimal GetTotalSalesByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            return realEstateDataList.Where(x => x.City.ToLower() == city.ToLower() && x.RealEstateType == realEstateType).Sum(x => x.Price);
        }

        public static int GetNumberOfSalesByRealEstateTypeAndZip(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string zipcode)
        {
            return realEstateDataList.Count(x => x.Zip == zipcode && x.RealEstateType == realEstateType);
        }

        
        public static decimal GetAverageSalePriceByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            //Must round to 2 decimal points
            return Math.Round(realEstateDataList.Where(x => x.City.ToLower() == city.ToLower() && x.RealEstateType == realEstateType).Average(x => x.Price), 2);
        }
        public static decimal GetAveragePricePerSquareFootByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            //Must round to 2 decimal points
            return Math.Round(realEstateDataList.Where(x => x.City.ToLower() == city.ToLower() && x.RealEstateType == realEstateType).Average(x => x.Price/x.Footage), 2);
        }

        public static int GetNumberOfSalesByDayOfWeek(List<RealEstateSale> realEstateDataList, DayOfWeek dayOfWeek)
        {
            return realEstateDataList.Count(x => x.SaleDate.DayOfWeek == dayOfWeek);
        }

        public static double GetAverageBedsByRealEstateTypeAndCityHigherThanPrice(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city, decimal price)
        {
            //Must round to 2 decimal points
            return Math.Round(realEstateDataList.Where(x => x.City.ToLower() == city.ToLower() && x.RealEstateType == realEstateType && x.Price > price).Average(x => x.Beds), 2);
        }

        public static List<string> GetTop5CitiesByNumberOfHomesSold(List<RealEstateSale> realEstateDataList)
        {
            // Taking out names of the cities
            return realEstateDataList.GroupBy(x => x.City).OrderByDescending(x => x.Count()).Select(x => x.Key).Take(5).ToList();
        }
    }

    public enum RealEstateType
    {
        //fill in with enum types: Residential, Multi-Family, Condo, Lot
        Residential,
        MultiFamily,
        Condo,
        Lot
    }
    class RealEstateSale
    {
        //street,city,zip,state,beds,baths,sq__ft,type,sale_date,price,latitude,longitude
        //Create properties, using the correct data types (not all are strings) for all columns of the CSV
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public int Footage { get; set; }

        public RealEstateType RealEstateType { get; set; }

        public DateTime SaleDate { get; set; }
        public decimal Price { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }

        //The constructor will take a single string arguement.  This string will be one line of the real estate data.
        // Inside the constructor, you will seperate the values into their corrosponding properties, and do the necessary conversions
        public RealEstateSale(string lineInput)
        {
            string[] FileData = lineInput.Split(',');

            this.Street = FileData[0];
            this.City = FileData[1];
            this.Zip = FileData[2];
            this.State = FileData[3];
            this.Beds = Int32.Parse(FileData[4]);
            this.Baths = Int32.Parse(FileData[5]);
            this.Footage = Int32.Parse(FileData[6]);

            if (this.Footage == 0)
	        {
            this.RealEstateType = RealEstateType.Lot;
	        }
            else if (FileData[7] == "Residential")
	        {
            this.RealEstateType = RealEstateType.Residential;
	        }
            else if (FileData[7] == "Multi-Family")
            {
                this.RealEstateType = RealEstateType.MultiFamily;
            }
            else if (FileData[7] == "Condo")
            {
                this.RealEstateType = RealEstateType.Condo;
            }

            this.SaleDate = DateTime.Parse(FileData[8]);
            this.Price = Int32.Parse(FileData[9]);
            this.Latitude = FileData[10];
            this.Longtitude = FileData[11];
        }
        //When computing the RealEstateType, if the square footage is 0, then it is of the Lot type, otherwise, use the string
        // value of the "Type" column to determine its corresponding enumeration type.
    }
}
