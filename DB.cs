using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Farm.Models;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Automation.Peers;
using Npgsql;

namespace Farm
{
    internal class DB
    {
        public string connection = "Host=localhost;Port=5432;Database=Farm;Username=postgres;Password=123;";
        public List<Field> getAllFields()
        {
            using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM fields";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    //command.Parameters.AddWithValue("@Login", login);
                    using (var reader = command.ExecuteReader())
                    {
                        List<Field> fields = new List<Field>();

                        while (reader.Read())
                        {
                            Field field = new Field
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["name"].ToString(),
                                Information = reader["information"].ToString(),
                            };

                            // Add the row to the list
                            fields.Add(field);
                        }

                        return fields;
                    }
                }
            }
        }

        public void updateField(int id, string name, string information)
        {
            string query = "UPDATE fields SET name = @Name, information = @Information WHERE Id = @Id";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Information", information);

                connection.Open();
                command.ExecuteNonQuery();
              
            }
        }

        public void deleteField(int id)
        {
            string query = "DELETE FROM fields WHERE id=@id";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
                
            }
        }

        public void addField(string name, string information)
        {
            string query = "INSERT INTO fields (name, information) VALUES (@Name, @Information)";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Information", information);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Field getFieldById(int id)
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM fields WHERE id = @Id";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Field field = new Field
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["name"].ToString(),
                                Information = reader["information"].ToString(),
                            };

                            return field;
                        }
                    }
                }
            }

            return new Field();
        }

        public Field getFieldByName(string name)
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM fields WHERE name = @Name";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Field field = new Field
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["name"].ToString(),
                                Information = reader["information"].ToString(),
                            };

                            return field;
                        }
                    }
                }
            }

            return new Field();
        }

        // Machinery
        public List<Machinery> getAllMachinery()
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM machinery";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        List<Machinery> machineryList = new List<Machinery>();

                        while (reader.Read())
                        {

                            Machinery machinery = new Machinery
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["name"].ToString(),
                                Information = reader["information"].ToString(),
                                FieldId = Convert.ToInt32(reader["field_id"]),
                            };

                            // Add the row to the list
                            machineryList.Add(machinery);
                        }

                        return machineryList;
                    }
                }
            }
        }

        public void updateMachinery(int id, string name, string information, int fieldId)
        {
            string query = "UPDATE machinery SET name = @Name, information = @Information, field_id = @FieldId WHERE Id = @Id";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Information", information);
                command.Parameters.AddWithValue("@FieldId", fieldId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void deleteMachinery(int id)
        {
            string query = "DELETE FROM machinery WHERE id=@id";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void addMachinery(string name, string information, int fieldId)
        {
            string query = "INSERT INTO machinery (name, information, field_id) VALUES (@Name, @Information, @FieldId)";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Information", information);
                command.Parameters.AddWithValue("@FieldId", fieldId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Machinery getMachineryById(int id)
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM machinery WHERE id = @Id";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Machinery machinery = new Machinery
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["name"].ToString(),
                                Information = reader["information"].ToString(),
                                FieldId = Convert.ToInt32(reader["field_id"]),
                            };

                            return machinery;
                        }
                    }
                }
            }

            return new Machinery();
        }

        // Seeds
        public List<Seeds> getAllSeeds()
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM seeds";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        List<Seeds> seedsList = new List<Seeds>();

                        while (reader.Read())
                        {

                            Seeds seeds = new Seeds
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Name = reader["name"].ToString(),
                                Weight = Convert.ToInt32(reader["weight"]),
                            };

                            seedsList.Add(seeds);
                        }

                        return seedsList;
                    }
                }
            }
        }

        public Seeds getSeedsById(int id)
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM seeds WHERE id = @Id";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Seeds seeds = new Seeds
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["name"].ToString(),
                                Weight = Convert.ToInt32(reader["weight"]),
                            };

                            return seeds;
                        }
                    }
                }
            }

            return new Seeds();
        }
        public Seeds getSeedByName(string name)
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM seeds WHERE name = @Name";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Seeds seeds = new Seeds
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Name = reader["name"].ToString(),
                                Weight = Convert.ToInt32(reader["weight"]),
                            };

                            return seeds;
                        }
                    }
                }
            }

            return new Seeds();
        }

        public void updateSeeds(int id, string name, int weight)
        {
            string query = "UPDATE seeds SET name = @Name, weight = @Weight WHERE Id = @Id";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Weight", weight);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void deleteSeeds(int id)
        {
            string query = "DELETE FROM seeds WHERE id=@id";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void addSeeds(string name, int weight)
        {
            string query = "INSERT INTO seeds (name, weight) VALUES (@Name, @Weight)";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Weight", weight);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        //Forecasts
        public List<Forecast> getAllForecasts()
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM forecasts";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        List<Forecast> forecasts = new List<Forecast>();

                        while (reader.Read())
                        {
                            Forecast forecast = new Forecast
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Description = reader["description"].ToString(),
                                Date = Convert.ToDateTime(reader["date"]),
                            };

                            // Add the row to the list
                            forecasts.Add(forecast);
                        }

                        return forecasts;
                    }
                }
            }
        }

        public void updateForecast(int id, string description, DateTime date)
        {
            string query = "UPDATE forecasts SET description = @Description, date = @Date WHERE Id = @Id";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Date", date);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void deleteForecast(int id)
        {
            string query = "DELETE FROM forecasts WHERE id=@id";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void addForecast(string description, DateTime date)
        {
            string query = "INSERT INTO forecasts (description, date) VALUES (@Description, @Date)";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Date", date);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public Forecast getForecastByDate(DateTime date)
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM forecasts WHERE date = @Date";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", date);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Forecast forecast = new Forecast
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Description = reader["description"].ToString(),
                                Date = Convert.ToDateTime(reader["date"]),
                            };

                            return forecast;
                        }
                    }
                }
            }

            return new Forecast();
        }

        public Forecast getForecastById(int id)
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM forecasts WHERE id = @Id";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Forecast forecast = new Forecast
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Description = reader["description"].ToString(),
                                Date = Convert.ToDateTime(reader["date"]),
                            };

                            return forecast;
                        }
                    }
                }
            }

            return new Forecast();
        }

        // Plans
        public List<Plan> getAllPlans()
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM plans";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        List<Plan> plans = new List<Plan>();

                        while (reader.Read())
                        {
                            Plan plan = new Plan
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                FieldId = Convert.ToInt32(reader["field_id"]),
                                SeedsId = Convert.ToInt32(reader["seeds_id"]),
                                Weight = Convert.ToInt32(reader["weight"]),
                                Date = Convert.ToDateTime(reader["date"]),
                            };
                 
                            plans.Add(plan);
                        }

                        return plans;
                    }
                }
            }
        }

        public void updatePlan(int id, int fieldId, int seedsId, int weight, DateTime date)
        {
            string query = "UPDATE plans SET field_id = @FieldId, seeds_id = @SeedsId, weight = @Weight, date = @Date WHERE Id = @Id";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@FieldId", fieldId);
                command.Parameters.AddWithValue("@SeedsId", seedsId);
                command.Parameters.AddWithValue("@Weight", weight);
                command.Parameters.AddWithValue("@Date", date);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void deletePlan(int id)
        {
            string query = "DELETE FROM plans WHERE id=@id";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void addPlan(int fieldId, int seedsId, int weight, DateTime date)
        {
            string query = "INSERT INTO plans (field_id, seeds_id, weight, date) VALUES (@FieldId, @SeedsId, @Weight, @Date)";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@FieldId", fieldId);
                command.Parameters.AddWithValue("@SeedsId", seedsId);
                command.Parameters.AddWithValue("@Weight", weight);
                command.Parameters.AddWithValue("@Date", date);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Plan getPlanById(int id)
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM plans WHERE id = @Id";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Plan plan = new Plan
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                FieldId = Convert.ToInt32(reader["field_id"]),
                                SeedsId = Convert.ToInt32(reader["seeds_id"]),
                                Weight = Convert.ToInt32(reader["weight"]),
                                Date = Convert.ToDateTime(reader["date"]),
                            };

                            return plan;
                        }
                    }
                }
            }

            return new Plan();
        }

        // Harvests


        public List<Harvest> getAllHarvests()
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM harvests";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        List<Harvest> harvests= new List<Harvest>();

                        while (reader.Read())
                        {
                            Harvest harvest= new Harvest
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                PlanId = Convert.ToInt32(reader["plan_id"]),
                                Date = Convert.ToDateTime(reader["date"]),
                                Weight = Convert.ToInt32(reader["weight"]),
                            };

                            // Add the row to the list
                            harvests.Add(harvest);
                        }

                        return harvests;
                    }
                }
            }
        }

        public void updateHarvest(int id, int planId, int weight, DateTime date)
        {
            string query = "UPDATE harvests SET plan_id = @PlanId, weight = @Weight, date = @Date WHERE Id = @Id";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@PlanId", planId);
                command.Parameters.AddWithValue("@Weight", weight);
                command.Parameters.AddWithValue("@Date", date);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void deleteHarvest(int id)
        {
            string query = "DELETE FROM harvests WHERE id=@id";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void addHarvest(int planId, int weight, DateTime date)
        {
            string query = "INSERT INTO harvests (plan_id, weight, date) VALUES (@PlanId, @Weight, @Date)";

           using (var connection = new NpgsqlConnection(this.connection))
            {
                var command=new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlanId", planId);
                command.Parameters.AddWithValue("@Weight", weight);
                command.Parameters.AddWithValue("@Date", date);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Harvest getHarvestById(int id)
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM harvests WHERE id = @Id";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Harvest harvest = new Harvest
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                PlanId = Convert.ToInt32(reader["plan_id"]),
                                Weight = Convert.ToInt32(reader["weight"]),
                                Date = Convert.ToDateTime(reader["date"]),
                            };

                            return harvest;
                        }
                    }
                }
            }

            return new Harvest();
        }

        public User getUserByPhone(string phone)
        {
           using (var connection = new NpgsqlConnection(this.connection))
            {
                connection.Open();
                string query = "SELECT * FROM users WHERE phone = @Phone";
                using (var command=new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Phone", phone);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            User user = new User
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Firstname = reader["firstname"].ToString(),
                                Middlename = reader["middlename"].ToString(),
                                Lastname = reader["lastname"].ToString(),
                                Phone = reader["phone"].ToString(),
                                Password = reader["password"].ToString(),
                            };

                            return user;
                        }
                    }
                }
            }

            return new User();
        }

    }
}
