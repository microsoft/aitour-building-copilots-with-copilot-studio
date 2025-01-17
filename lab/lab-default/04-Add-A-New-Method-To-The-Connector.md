# 4 - Add a New Method To The Connector

Right now our API is setup with a method to get order details. Before we publish this as a connector, lets add one more method that can we can use to update the delivery address for an order. This will help us demonstrate how plugin actions in Copilot Studio can be used both to return information and submit information back to our API.

1. Add the following code in the **OrderControl.cs** file after the comment that says **Start Exercise Space**
<br>
    ![step34.jpg](./images/instructions273634/step34.jpg)
<br>
    **Code:**

    ```
    [SwaggerOperation(OperationId="UpdateDeliveryAddress",
    Summary="Update delivery address",
    Description= "Update the delivery address for the order number provided then return the updated delivery details" )]
    //This is the definition for the HttpPost controller path 
    [HttpPost(Name = "/UpdateDeliveryAddress/{orderNumber}/{street}/{city}/{state}/{zipcode}")]
    
    //Crate a new public method that will return an order
    public Order UpdateDeliveryAddress(
    [SwaggerParameter("The Order number to be updated", Required= true)] string orderNumber,
    [SwaggerParameter("The updated Street Address", Required=true)] string street,
    [SwaggerParameter("The updated City name",Required= true)] string city,
    [SwaggerParameter("The updated State", Required=true)] string state,
    [SwaggerParameter("The udpated Zip Code", Required=true)] string zipcode
    )
    {
    Order orderToUpdate = GetOrderDetails(orderNumber);
    orderToUpdate.OrderDetails.ShippingAddress.Street = street;
    orderToUpdate.OrderDetails.ShippingAddress.City = city;
    orderToUpdate.OrderDetails.ShippingAddress.State = state;
    orderToUpdate.OrderDetails.ShippingAddress.ZipCode = zipcode;
    return orderToUpdate;
    }
    ```
 1. Confirm that the final code matches the screenshot below
<br>
    ![step38.jpg](./images/instructions273634/step38.jpg)
8. Now let's test our new method before publishing the connector to make sure it works. Run your application locally again by clicking the **run** button
<br>
    ![step39.jpg](./images/instructions273634/step39.jpg)
9. There will be a new Post method available in the ContosoApiApp
<br>
    ![step40.jpg](./images/instructions273634/step40.jpg)
10. Click the new **Post** method and click **Try it out**
<br>
    ![step41.jpg](./images/instructions273634/step41.jpg)
11. Enter the required details and click **Execute** to test
<br>
    ![step42.jpg](./images/instructions273634/step42.jpg)
12. Scroll down to see the response and confirm the method is responding as expected
<br>
    ![step43.jpg](./images/instructions273634/step43.jpg)
13. Close the browser window to stop the application
