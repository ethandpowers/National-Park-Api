using Csv;
using NationalParkApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NationalParkApi.Data
{
    public class DbInit
    {

        public static void Initialize(NpContext _context)
        {
            try
            {
                //Lists of of objects to be nested within one another
                List<Park> Parks = new List<Park>();

                var csv = File.ReadAllText("Data/parks.csv");
                foreach (var line in CsvReader.ReadFromText(csv))
                {
                    Park currentPark = (new Park
                    {
                        Code = line[0],
                        Name = line[1],
                        Acres = double.Parse(line[3]),
                        Latitude = double.Parse(line[4]),
                        Longitude = double.Parse(line[5])
                    });
                    foreach(string state in line[2].Split(',').ToList())
                    {
                        currentPark.States.Add(new State
                        {
                            Name = state
                        }) ;
                    }

                    Parks.Add(currentPark);
                }

                csv = File.ReadAllText("Data/species.csv");
                foreach (var line in CsvReader.ReadFromText(csv))
                {
                    Species species = new Species
                    {
                        Species_ID = line["Species ID"],
                        Park = line["Park Name"],
                        Category = line["Category"],
                        Order = line["Order"],
                        Family = line["Family"],
                        Scientific_Name = line["Scientific Name"]
                    };

                    foreach(string name in line["Common Names"].Split(',').ToList())
                    {
                        species.Common_Names.Add(new CommonName
                        {
                            Name = name
                        }) ;
                    }

                    //since the Csv library isn't working with null values, the war lines are extrated and manually parsed into a list, then assigned manually
                    string raw = line.Raw;
                    List<string> list = raw.Split(',').ToList();
                    species.Record_Status = list.ElementAt(7);
                    species.Occurance = list.ElementAt(8);
                    species.Nativeness = list.ElementAt(9);
                    species.Abundance = list.ElementAt(10);
                    species.Seasonality = list.ElementAt(11);
                    species.Conservation_Status = list.ElementAt(12);

                    //get the park object that matches the species
                    Park currentPark = Parks.Where(p => p.Name == species.Park).FirstOrDefault();
                    
                    //check if the park contains the category of the speciese
                    if(!currentPark.Categories.Where(c => c.Name == species.Category).Any())
                    {
                        currentPark.Categories.Add(new Category { Name = species.Category });
                    }
                    Category currentCategory = currentPark.Categories.Where(c => c.Name == species.Category).FirstOrDefault();

                    //check if the category contains an order that matches the species
                    if(!currentCategory.Orders.Where(o => o.Name == species.Order).Any())
                    {
                        currentCategory.Orders.Add(new Order { Name = species.Order });
                    }
                    Order currentOrder = currentCategory.Orders.Where(o => o.Name == species.Order).FirstOrDefault();

                    //check if the order contains a family that matches the species
                    if(!currentOrder.Families.Where(f => f.Name == species.Family).Any())
                    {
                        currentOrder.Families.Add(new Family { Name = species.Family });
                    }
                    Family currentFamily = currentOrder.Families.Where(f => f.Name == species.Family).FirstOrDefault();
                    currentFamily.Species.Add(species);
                }


                foreach(var park in Parks)
                {
                    _context.Parks.Add(park);
                }

                //handle the trails
                List<Trail> trails = new List<Trail>();
                csv = File.ReadAllText("Data/trails.csv");
                foreach (var line in CsvReader.ReadFromText(csv))
                {
                    Trail trail = new Trail
                    {
                        trailID = line[0],
                        name = line[1],
                        areaName = line[2],
                        cityName = line[3],
                        stateName = line[4],
                        popularity = double.Parse(line["popularity"]),
                        length = double.Parse(line["length"]),
                        elevation = double.Parse(line["elevation_gain"]),
                        difficultyRating = int.Parse(line["difficulty_rating"]),
                        routeType = line["route_type"],
                        avgRating = double.Parse(line["avg_rating"]),
                        numReviews = int.Parse(line["num_reviews"]),
                        units = line["units"]
                    };

                    
                    string visitorUsage = line["visitor_usage"];
                    if (visitorUsage != "")
                    {
                        trail.visitorUsage = int.Parse(visitorUsage);
                    }
                    else
                    {
                        trail.visitorUsage = -1;
                    }

                    foreach (string str in line["features"].Split(',').ToList()){
                        trail.features.Add(new Feature { feature = str.Trim(new Char[] { ' ', '[', ']', Char.Parse("'") })});
                    }

                    foreach (string str in line["activities"].Split(',').ToList())
                    {
                        trail.activities.Add(new Activity { activity = str.Trim(new Char[] { ' ', '[', ']', Char.Parse("'") }) });
                    }
                    //trail initialized, now add to database

                    trails.Add(trail);
                }

                foreach(var tr in trails)
                {
                    _context.Trails.Add(tr);
                }
                _context.SaveChanges();
                Console.WriteLine("Database initialized");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
