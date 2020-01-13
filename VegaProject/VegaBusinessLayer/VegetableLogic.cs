using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VegaModel;

namespace VegaBusinessLayer
{
    public class VegetableLogic : BaseRepository<VegetableModel>
    {
         public VegetableLogic(IGenericRepository<VegetableModel> repository) : base(repository)
        {
        }
        public bool Authenticate(string vegName)
        {
            VegetableModel poco = base.GetAll().Where(s => s.Vegetable == vegName).FirstOrDefault();

            if (null == poco)
            {
                return false;
            }
            return true;
         }

        public override void Add(VegetableModel poco)
        {
              Verify(poco);
             base.Add(poco);
          }

        public override void Update(VegetableModel pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        public override void Delete(int Id)
        {
              base.Delete(Id);
        }

        protected override void Verify(VegetableModel poco)
        {
            List<ValidationException> exceptions = new List<ValidationException>();

            if (string.IsNullOrEmpty(poco.Vegetable))
            {
                exceptions.Add(new ValidationException(705, "VegetableName is required."));
            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
