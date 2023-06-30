using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApplication.Modul;

namespace CrudApplication.Class.CrudApplicationRepository
{
    public class CrudApplicationRepo
    {
        public int AddPersonDetail(PersonDetailModal Person)
        {
            using (var context = new CrudApplicatonEntities())
            {
                PersonDetail detail = new PersonDetail()
                {
                    FirstName = Person.FirstName,
                    LastName = Person.LastName,
                    Email = Person.Email,
                };

                if (Person.Address != null)
                {
                    detail.AddressDetail = new AddressDetail()
                    {
                        Street = Person.Address.Street,
                        City = Person.Address.City,
                        State = Person.Address.State,
                        PostCode = Person.Address.PostCode,
                        Country = Person.Address.Country,
                    };

                }

                context.PersonDetail.Add(detail);
                context.SaveChanges();
                return detail.Id;
            }
        }

        public List<PersonDetailModal> GetPerosonDetail()
        {
            using (var context = new CrudApplicatonEntities())
            {
                var result = context.PersonDetail.Select(x => new PersonDetailModal()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Address = new AddressDetailModal()
                    {
                        Id = x.AddressDetail.Id,
                        Street = x.AddressDetail.Street,
                        City = x.AddressDetail.City,
                        State = x.AddressDetail.State,
                        PostCode = x.AddressDetail.PostCode,
                        Country = x.AddressDetail.Country
                    }

                }).ToList();
                return result;
            }
        }

        public PersonDetailModal PersonIndividualDetail(int id)
        {
            using (var context = new CrudApplicatonEntities())
            {
                var resultIndividualDetail = context.PersonDetail.Where(x => x.Id == id).Select(x => new PersonDetailModal()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Address = new AddressDetailModal()
                    {
                        Id = x.AddressDetail.Id,
                        Street = x.AddressDetail.Street,
                        City = x.AddressDetail.City,
                        State = x.AddressDetail.State,
                        PostCode = x.AddressDetail.PostCode,
                        Country = x.AddressDetail.Country
                    }
                }).FirstOrDefault();
                return resultIndividualDetail;
            }
        }

        public bool PersonEditDetail(int id, PersonDetailModal Person)
        {
            using (var context = new CrudApplicatonEntities())
            {
                var resultEditDetail = context.PersonDetail.Where(x => x.Id == id).FirstOrDefault();

                if (resultEditDetail != null)
                {
                    resultEditDetail.FirstName = Person.FirstName;
                    resultEditDetail.LastName = Person.LastName;
                    resultEditDetail.Email = Person.Email;
                    resultEditDetail.AddressDetail.Street = Person.Address.Street;
                    resultEditDetail.AddressDetail.City = Person.Address.City;
                    resultEditDetail.AddressDetail.State = Person.Address.State;
                    resultEditDetail.AddressDetail.PostCode = Person.Address.PostCode;
                    resultEditDetail.AddressDetail.Country = Person.Address.Country;
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteDetail(int id)
        {
            using (var context = new CrudApplicatonEntities())
            {
                var DeleteDetail = context.PersonDetail.FirstOrDefault(x => x.Id == id);
                if (DeleteDetail != null)
                {
                    context.PersonDetail.Remove(DeleteDetail);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
