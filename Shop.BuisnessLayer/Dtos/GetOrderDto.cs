using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BuisnessLayer.Dtos
{


    /*
     1 класс - гет бай ід +
     2 - гет алл -   // створити класс для видображення списку  (  CompanyCustomerResponse  ) дата , имья , количество строк ,  загальна сума
     3- кріейт     +
     4- команда аналогічна кріейт    + 
         */


    public class GetOrderDto:BaseDto
    {

        // get byid(GetCustomerResponse) and for editing form    
       
        public List<OrderPunctDto> Orderpuncts { get; set; }

       
        
        
        /* фронт обичние дто и криейт дто 
        1 - отображение ордера как тут дто 
        2-  отображения для редактирования  (ордер дто)
        3- редактирование (криейт ордер )
        4- отображение редактирование ордер пункт (ордер пункт дто)
        5- редактирование (криейт ордер пункт дто)

    */
    }
}
