using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCCorp.Models;
using SWCCorp.Models.Interfaces;
using SWCCorp.Models.Responses;
using SWCCorp.BLL.Validation;
using SWCCorp.Data;

namespace SWCCorp.BLL.Rules
{
    public class AddRules : IAdd
    {
        public AddResponse Add(Order order, string date, string name, Products productType, string state = "", decimal area = 0)
        {
            AddResponse response = new AddResponse();
            DataValidation validate = new DataValidation();

            string validDate = validate.checkDate(date);

            //Order Date – The date must be in the future.
            if (DateTime.Parse(validDate) <= DateTime.Today)
            {
                response.Success = false;
                response.Message = $"Error: Date prior to {DateTime.Today}";
                return response;
            }

            //Customer Name– This field may not be blank; it is allowed to contain [a-z][0-9] as well as periods and comma characters. “Acme, Inc.” is a valid name.
            string validName = validate.checkNameChange(name);

            //State– Entered states must be checked against the tax file. If the state does not exist in the tax file, we cannot sell there. If a state is added to the tax file later, it should be included without changing the application code.



            //Product Type– Show a list of available products and pricing information to choose from. Again, if a product is added to the file, it should show up in the application without a code change.

            //Area– The area must be a positive decimal.Minimum order size is 100 square feet.

            return null;
        }
    }
}
