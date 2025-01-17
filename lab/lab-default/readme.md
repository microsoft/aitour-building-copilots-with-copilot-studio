# @lab.Title


In this lab you’ll work with Microsoft Copilot Studio to build your first agent using Generative answers, you’ll then publish this agent to Microsoft Teams.

In the second half of this workshop, you'll extend your agent with a custom connector that you’ll build in Visual Studio, publish this as custom connector and then add this as an action to your agent.

The green text with the +++icon+++ can be clicked on and will be typed automatically into the VM, For example, please click in the password text box and then click the password: +++@lab.VirtualMachine(WRK530).Password+++

> [!note] To ensure text is entered accurately avoid interacting or clicking in the VM until the text has finished being typed

===

!INSTRUCTIONS [1 - Build Your First Agent](https://raw.githubusercontent.com/microsoft/aitour-building-copilots-with-copilot-studio/refs/heads/main/lab/lab-default/01-Build-Your-First-Agent.md)

===

# 2 - Publishing Your Agent

Now that you have confirmed your agent is working as expected let’s publish the agent. This allows you to then use your agent in other channels like embedding on your public website or using inside of Microsoft Teams


1. Click the **Publish** button in the top right-hand corner
<br>
    ![AgentPublish.png](./images/instructions273634/AgentPublish.png)

1. Click the **Publish** button to publish your agent
<br>
    ![publish-agent.png](./images/instructions273634/publish-agent.png)
<br>
    The following dialog will be displayed you can close this and your agent will finish publishing in the background
<br>
    ![publishing-agent.png](./images/instructions273634/publishing-agent.png)
1. Now that it’s published, we need to make this available to use within Microsoft Teams. Select the **Channels** tab in the top menu
<br>
   ![AgentChannels.png](./images/instructions273634/AgentChannels.png)
1. Under the list of channels, select **Microsoft Teams**
![AgentChannelsTeams.png](./images/instructions273634/AgentChannelsTeams.png)
<br>
1. In the panel that opens on the right-hand side, select **Turn on Teams**
<br>
    ![step20.png](./images/instructions273634/step20.png)
1. After Teams is turned on, you’ll get a message letting you know the channel was added. Select **Open agent** to add your new agent to Teams
<br>
   ![AgentOpen.png](./images/instructions273634/AgentOpen.png).
1. Choose **Use the web app instead**
<br>
    ![step22.png](./images/instructions273634/step22.png)
1. You’ll see a preview of your agent. Select **Add**
<br>
   ![AgentAdd.png](./images/instructions273634/AgentAdd.png)
24. Your agent is now added and accessible in Microsoft Teams. Test your agent by asking +++What are the specs for the latest Surface laptop?+++ in the prompt input and press Enter
<br>
![AgentTeamsTest.png](./images/instructions273634/AgentTeamsTest.png)
Congratulations! You’ve now built and published an agent to Microsoft Teams!

===

# 3 - Extending Agent With Custom Connectors

In the last portion of the workshop, we showed you how to build a agent that uses Generative Answers as a source of information.

Now you'll step through how to build a custom connector that can be used as a plugin for your agents. Plugins allows agents to work with other systems, expanding your agents capabilities beyond answering questions.

In this example we will work with a custom API that can look up order details and then extend that scenario by adding a method to update the delivery address of a returned order.

1. In your Windows Task bar at the bottom of your VM, select the Visual Studio icon to launch Visual Studio.
![AgentVS.png](./images/instructions273634/AgentVS.png)
1. In the **Open Recent** section on the left hand side, select the **ContosoApiApp file** which is located on the D drive at +++**D:\LabFiles\ContosoApiApp\ContosoApiApp**+++ 
![AgentsVSOPEN.png](./images/instructions273634/AgentsVSOPEN.png)
** If you don't see this in the Open recent section, select "Open a project or solution" on the right and browse to the file path mentioned above and select the ContosoApiApp.sln file.
1. There might be a sign in to Visual Studio pop up, feel free to click **Close** in that screen.
2. This is the solution we will be building on to create a custom connector for our agent. Before continuing press **Ctrl+ Shift + B** to build the solution
<br>
    ![step26.jpg](./images/instructions273634/step26.jpg)
3. While our app is technically set to run in HTTPS we are going to test it locally first Click the arrow next to **https** in the tool bar and select **http**

    > [!note] We will switch this back before publishing this to Microsoft Copilot Studio

    ![step27.jpg](./images/instructions273634/step27.jpg)
4. Click the **Run** button to run your application
<br>
    ![step28.jpg](./images/instructions273634/step28.jpg)
5. Click **Yes** on the **Trust ASP.NET Core SSL Certificate** dialog
<br>
    ![step69.jpg](./images/instructions273634/step69.jpg)
6. Click **Yes** on the security warning dialog to install the certificate
<br>
    ![step70.jpg](./images/instructions273634/step70.jpg)
5. Once the application is running it will appear in a new browser window showing the details about the objects and methods you can test.
<br>
    ![step29.jpg](./images/instructions273634/step29.jpg)
6. Click the **Get** method and then click the **Try it out** button to test the get method
<br>
    ![step30.jpg](./images/instructions273634/step30.jpg)
7. Enter an order number (any number will work) then click the **Execute** button
<br>
    ![step31.jpg](./images/instructions273634/step31.jpg)
8. Scroll down to see the response returned from the **GetOrderDetails** method
<br>
    ![step32.jpg](./images/instructions273634/step32.jpg)
9. Close the browser window to stop the App running

===

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

===

# 5 - Adding Connector To Microsoft Copilot Studio

With the connector built and the new post method added it's time to add this to Microsoft Copilot Studio so it can be used by the Generative Actions engine.

1. Before publishing the connector, we need to change the run mode from http back to https, click the arrow next to **http** and select **https**
<br>
    ![step45.jpg](./images/instructions273634/step45.jpg)
1. In the solution explorer on the right side, **Right click>Connected Services>Add>Microsoft Power Platform**
<br>
    ![step46.jpg](./images/instructions273634/step46.jpg)
1. In the top right of the **Connect to Microsoft Power Platform** dialog click **Sign in>Work, School or personal account** then use your tenant credentials to login to connect to the Power Platform.

    **Username:** +++@lab.CloudCredential(CSBatch1).UserPrincipalName+++


    **Password:** +++@lab.CloudCredential(CSBatch1).Password+++
        
    **Temporary Access Password:** +++@lab.Variable(TAP)+++

    ![step47.jpg](./images/instructions273634/step47.jpg)
1. Check to make sure the **AI Roadshow (default)** environment is selected and that the **Common Data Services Default Solution** is selected then click the **Plus(+)** button to create a new custom connector
<br>
    ![AgentsVSConnectService.png](./images/instructions273634/AgentsVSConnectService.png)
1. Accept the **Power Platform environment**. Update the **Custom connector name** to **Your First and Last Name Plus the word Connector**, for example, Jane Doe Connector. Then click **Create**. It's very important to remember this name as you'll need to reference this in later steps!


<br>
![AgentsVSAddConnector.png](./images/instructions273634/AgentsVSAddConnector.png)
1. Next, you're going to create a Dev Tunnel so you can test your Connector. Click the **Plus (+)** button to create a public dev tunnel which will allow you to debug the connector when it's called from our agent
<br>
![AgentVSDevTunnel.png](./images/instructions273634/AgentVSDevTunnel.png)
1. In the **Name** field, put **Your First and Last Name plus the world DevTunnel** for your Dev tunnel name then click the **Ok** button
<br>
    ![AgentsVSDevTunnelName.png](./images/instructions273634/AgentsVSDevTunnelName.png)
1. Click **Next** to see a summary of the changes to be made
<br>
    ![step52.jpg](./images/instructions273634/step52.jpg)
1. Click Finish to create the connector
<br>
    ![image.png](./images/instructions273634/image.png)
1. Wait for the connector to be created then click **Close**
<br>
    ![step54.jpg](./images/instructions273634/step54.jpg)

===

!INSTRUCTIONS [6 - Adding the Contoso Plugin to your Agent](https://raw.githubusercontent.com/microsoft/aitour-building-copilots-with-copilot-studio/refs/heads/main/lab/lab-default/06-Adding-The-Contoso-Plugin-To-Your-Agent.md)
