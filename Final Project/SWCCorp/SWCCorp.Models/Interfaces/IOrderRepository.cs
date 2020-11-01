using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Display order by given date
 * Add order with user prompts
        Order Date – The date must be in the future.
        Customer Name– This field may not be blank; it is allowed to contain [a-z][0-9] as well as periods and comma characters. “Acme, Inc.” is a valid name.
        State– Entered states must be checked against the tax file. If the state does not exist in the tax file, we cannot sell there. If a state is added to the tax file later, it should be included without changing the application code.
        Product Type– Show a list of available products and pricing information to choose from. Again, if a product is added to the file, it should show up in the application without a code change.
        Area – The area must be a positive decimal. Minimum order size is 100 square feet.
        The remaining fields are calculated from the user entry and the tax/product information in the files. Show a summary of the order once the calculations are completed and prompt the user as to whether they want to place the order (Y/N). If yes, the data will be written to the orders file with the appropriate date (create a new file if it is the first order on the date). If no, simply return to the main menu.

        The system should generate an order number for the user based on the next available order number in the file (so if there are two orders and the highest order number is 4, the next order number should be 5).
 * Edit Order by date and order number.
        CustomerName, State, ProductType, Area
 * Remove Order by date and order number.
 */
namespace SWCCorp.Models.Interfaces
{
    public interface IOrderRepository
    {
        Order DisplayOrders(string date);
        void SaveOrder(Order order);
    }
}
