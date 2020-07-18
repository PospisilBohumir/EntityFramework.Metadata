using System;
using System.Diagnostics;
using EntityFramework.Metadata.Extensions;
using EntityFramework.Metadata.Test.CodeFirst.Domain;
using Xunit;
using static Xunit.Assert;

namespace EntityFramework.Metadata.Test.CodeFirst
{
    public class MappingTest : TestBase
    {
        [Fact]
        public void TableNames()
        {
            using (var ctx = GetContext())
            {
                var sw = new Stopwatch();
                sw.Restart();
                var dbmapping = ctx.Db();
                sw.Start();

                Console.WriteLine("Mapping took: {0}ms", sw.Elapsed.TotalMilliseconds);

                foreach (var tableMapping in dbmapping)
                {
                    Console.WriteLine("{0}: {1}.{2}", tableMapping.Type.FullName, tableMapping.Schema,
                        tableMapping.TableName);
                }

                Equal(ctx.Db<Page>().TableName, "Pages");
                Equal(ctx.Db<Page>().Schema, "dbo");
                Equal(ctx.Db<PageTranslations>().TableName, "PageTranslations");

                Equal(ctx.Db<TestUser>().TableName, "Users");

                Equal(ctx.Db<MeteringPoint>().TableName, "MeteringPoints");

                Equal(ctx.Db<EmployeeTPH>().TableName, "Employees");
                Equal(ctx.Db<AWorkerTPH>().TableName, "Employees");
                Equal(ctx.Db<ManagerTPH>().TableName, "Employees");

                Equal(ctx.Db<ContractBase>().TableName, "Contracts");
                Equal(ctx.Db<Contract>().TableName, "Contracts");
                Equal(ctx.Db<ContractFixed>().TableName, "Contracts");
                Equal(ctx.Db<ContractStock>().TableName, "Contracts");
                Equal(ctx.Db<ContractKomb1>().TableName, "Contracts");
                Equal(ctx.Db<ContractKomb2>().TableName, "Contracts");

                Equal(ctx.Db<WorkerTPT>().TableName, "WorkerTPTs");
                Equal(ctx.Db<ManagerTPT>().TableName, "ManagerTPTs");

                Equal(ctx.Db<Foo>().TableName, "FOO");
                Equal(ctx.Db<Foo>().Schema, "dbx");
            }
        }

        [Fact]
        public void Entity_WithMappedPk()
        {
            using (var ctx = GetContext())
            {
                var map = ctx.Db<EntityWithMappedPk>();
                Console.WriteLine("{0}:{1}", map.Type, map.TableName);

                map.Prop(x => x.BancoId)
                    .HasColumnName("BancoID")
                    .IsPk()
                    .IsFk(false)
                    .IsRequired()
                    .IsIdentity(false)
                    .IsNavigationProperty(false);
            }
        }

        [Fact]
        public void Entity_ComplexType()
        {
            using (var ctx = new TestContext())
            {
                var map = ctx.Db<TestUser>();

                map.Prop(x => x.Id)
                    .HasColumnName("Id")
                    .IsPk()
                    .IsFk(false)
                    .IsNavigationProperty(false);

                map.Prop(x => x.FirstName)
                    .HasColumnName("Name")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.LastName)
                    .HasColumnName("LastName")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Contact.PhoneNumber)
                    .HasColumnName("Contact_PhoneNumber")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Contact.BusinessAddress.StreetAddress)
                    .HasColumnName("Contact_BusinessAddress_StreetAddress")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Contact.BusinessAddress.County)
                    .HasColumnName("Contact_BusinessAddress_County")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Contact.BusinessAddress.Country)
                    .HasColumnName("Contact_BusinessAddress_Country")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Contact.BusinessAddress.City)
                    .HasColumnName("Contact_BusinessAddress_City")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Contact.BusinessAddress.PostalCode)
                    .HasColumnName("Contact_BusinessAddress_PostalCode")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Contact.ShippingAddress.StreetAddress)
                    .HasColumnName("Contact_ShippingAddress_StreetAddress")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Contact.ShippingAddress.Country)
                    .HasColumnName("Contact_ShippingAddress_Country")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Contact.ShippingAddress.County)
                    .HasColumnName("Contact_ShippingAddress_County")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Contact.ShippingAddress.City)
                    .HasColumnName("Contact_ShippingAddress_City")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Contact.ShippingAddress.PostalCode)
                    .HasColumnName("Contact_ShippingAddress_PostalCode")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);
#if !NET40
                var propertyPropertyMap = map.Prop(x => x.Contact.ShippingAddress.Location);
                propertyPropertyMap
                    .HasColumnName("Contact_ShippingAddress_Location")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false);

                Console.WriteLine(propertyPropertyMap.DefaultValue);
                Console.WriteLine(propertyPropertyMap.FixedLength);
                Console.WriteLine(propertyPropertyMap.MaxLength);
                Console.WriteLine(propertyPropertyMap.Precision);
                Console.WriteLine(propertyPropertyMap.Scale);
                Console.WriteLine(propertyPropertyMap.Type);
                Console.WriteLine(propertyPropertyMap.Unicode);

                var shapePropertyMap = map.Prop(x => x.Contact.ShippingAddress.Shape);
                shapePropertyMap
                    .HasColumnName("Contact_ShippingAddress_Shape")
                    .IsPk(false)
                    .IsFk(false)
                    .IsNavigationProperty(false);

                Console.WriteLine(shapePropertyMap.DefaultValue);
                Console.WriteLine(shapePropertyMap.FixedLength);
                Console.WriteLine(shapePropertyMap.MaxLength);
                Console.WriteLine(shapePropertyMap.Precision);
                Console.WriteLine(shapePropertyMap.Scale);
                Console.WriteLine(shapePropertyMap.Type);
                Console.WriteLine(shapePropertyMap.Unicode);
#endif
            }
        }

        [Fact]
        public void Entity_ComplexType_WhereComplexTypeIsLastProperty()
        {
            using (var ctx = new TestContext())
            {
                var map = ctx.Db<House>();

                map.Prop(x => x.Name)
                    .HasColumnName("Name");

                map.Prop(x => x.Address.Country)
                    .HasColumnName("Address_Country");
            }
        }

        [Fact]
        public void Entity_ComplexType_WhereTwoComplexTypesAreAdjacent()
        {
            using (var ctx = new TestContext())
            {
                var map = ctx.Db<Company>();

                map.Prop(x => x.FirstContact.BusinessAddress.StreetAddress)
                    .HasColumnName("FirstContact_BusinessAddress_StreetAddress");

                map.Prop(x => x.FirstContact.ShippingAddress.StreetAddress)
                    .HasColumnName("FirstContact_ShippingAddress_StreetAddress");

                map.Prop(x => x.BusinessAddress.StreetAddress)
                    .HasColumnName("BusinessAddress_StreetAddress");

                map.Prop(x => x.ShippingAddress.StreetAddress)
                    .HasColumnName("ShippingAddress_StreetAddress");
            }
        }

        [Fact]
        public void Entity_TPT_WorkerTPT()
        {
            using (var ctx = GetContext())
            {
                var map = ctx.Db<WorkerTPT>();

                map.Prop(x => x.Id)
                    .IsPk()
                    .IsFk(false)
                    .HasColumnName("Id")
                    .IsNavigationProperty(false);

                map.Prop(x => x.Name)
                    .IsPk(false)
                    .IsFk(false)
                    .HasColumnName("Name")
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.JobTitle)
                    .IsPk(false)
                    .IsFk(false)
                    .HasColumnName("JobTitle")
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Boss)
                    .IsPk(false)
                    .IsFk()
                    .HasColumnName("Boss_Id")
                    .IsNavigationProperty();

                var refereeIdProp = map.Prop(x => x.RefereeId);
                refereeIdProp
                    .IsPk(false)
                    .IsFk()
                    .HasColumnName("RefereeId")
                    .IsNavigationProperty(false)
                    .NavigationPropertyName("Referee");

                
                
                map.Prop(x => x.Referee)
                    .HasColumnName("RefereeId")
                    .IsPk(false)
                    .IsFk(false)
                    .IsIdentity(false)
                    .IsNavigationProperty()
                    .ForeignKeyPropertyName("RefereeId")
                    .ForeignKey(refereeIdProp);
            }
        }

        [Fact]
        public void Entity_TPT_ManagerTPT()
        {
            using (var ctx = GetContext())
            {
                var map = ctx.Db<ManagerTPT>();

                map.Prop(x => x.Id)
                    .IsPk()
                    .IsFk(false)
                    .HasColumnName("Id")
                    .IsNavigationProperty(false);

                map.Prop(x => x.Name)
                    .IsPk(false)
                    .IsFk(false)
                    .HasColumnName("Name")
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.JobTitle)
                    .IsPk(false)
                    .IsFk(false)
                    .HasColumnName("JobTitle")
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.Rank)
                    .IsPk(false)
                    .IsFk(false)
                    .HasColumnName("Rank")
                    .IsNavigationProperty(false);
            }
        }

        [Fact]
        public void Entity_Simple()
        {
            using (var ctx = new TestContext())
            {
                var map = ctx.Db<Page>();
                Console.WriteLine("{0}:{1}", map.Type, map.TableName);

                map.Prop(x => x.PageId)
                    .HasColumnName("PageId")
                    .IsPk()
                    .IsFk(false)
                    .IsIdentity()
                    .IsNavigationProperty(false);

                map.Prop(x => x.Title)
                    .HasColumnName("Title")
                    .IsPk(false)
                    .IsFk(false)
                    .IsIdentity(false)
                    .IsRequired()
                    .IsNavigationProperty(false)
                    .MaxLength(255);

                map.Prop(x => x.Content)
                    .HasColumnName("Content")
                    .IsPk(false)
                    .IsFk(false)
                    .IsIdentity(false)
                    .IsRequired(false)
                    .IsNavigationProperty(false)
                    .MaxLength(NvarcharMax);

                map.Prop(x => x.ParentId)
                    .HasColumnName("ParentId")
                    .IsPk(false)
                    .IsFk()
                    .IsIdentity(false)
                    .IsRequired(false)
                    .IsNavigationProperty(false)
                    .NavigationPropertyName("Parent");

                Equal(map.Prop(x => x.PageId), map.Prop(x => x.ParentId).FkTargetColumn);
               
                map.Prop(x => x.Parent)
                    .HasColumnName("ParentId")
                    .IsPk(false)
                    .IsFk(false)
                    .IsIdentity(false)
                    .IsNavigationProperty()
                    .ForeignKeyPropertyName("ParentId")
                    .ForeignKey(map.Prop(x => x.ParentId));
                
                map.Prop(x => x.CreatedAt)
                    .HasColumnName("CreatedAt")
                    .IsPk(false)
                    .IsFk(false)
                    .IsIdentity(false)
                    .IsRequired(true)
                    .IsNavigationProperty(false);

                map.Prop(x => x.ModifiedAt)
                    .HasColumnName("ModifiedAt")
                    .IsPk(false)
                    .IsFk(false)
                    .IsRequired(false)
                    .IsIdentity(false)
                    .IsNavigationProperty(false);
            }
        }
    }
}
