# 6 - Adding the Contoso Plugin to your Agent

1. Reopen the **Microsoft Edge** window from the start of the lab and click on the Copilot Studio tab

1. Click on the **Settings** button on the right of the top nav bar

    ![step56.jpg](./images/instructions273634/step56.jpg)

1. Click on **Generative AI** in the left navigation

    ![AgentsGenAI.png](./images/instructions273634/AgentsGenAI.png)

1. Confirm that the **Generative** option is selected then click **Save**

    ![step58.png](./images/instructions273634/step58.png)

1. Click on **Close (x)** button to close out of settings and get back to your agent

    ![AgentGenAIClose.png](./images/instructions273634/AgentGenAIClose.png)

1. Click on the **Actions** option in the top nav

    ![AgentsActions.png](instructions273634/AgentsActions.png)

1. Click the **+ Add an action** button to add a new action

    ![step61.jpg](./images/instructions273634/step61.jpg)

1. Enter **the name of your connector from the Visual Studio Connected Service step (your first name last name connector)** in the search field and hit **Enter**

    ![AgentConnectorSearch.png](./images/instructions273634/AgentConnectorSearch.png)

1. You may have to scroll down in the list of connectors to find your results. Once you do, you will see 2 actions returned from your connector. Each of these actions represents one of the methods in the connector that you just published from Visual Studio. 

    ![AgentConnectorResults.png](./images/instructions273634/AgentConnectorResults.png)

1. Click **Get Order Details** to begin adding this action to your agent

    ![AgentGetOrderDetails2.png](./images/instructions273634/AgentGetOrderDetails2.png)

1. Once the connector has loaded, in the End user authentication dropdown, select **Copilot author authentication** then click **Next**

    ![AgentOrderDetailsAuth.png](./images/instructions273634/AgentOrderDetailsAuth.png)

1. On the Inputs and Outputs screen, click **Next** again.

    ![AgentOrderDetailsNext.png](./images/instructions273634/AgentOrderDetailsNext.png)

1. Click **Finish** to complete adding the Get Order Details plugin action.

    ![step66.jpg](./images/instructions273634/step66.jpg)

1. On the next screen, select **Add Action** to add the other action from our connector.

![AgentAddSecondAction.png](./images/instructions273634/AgentAddSecondAction.png)

1. Enter **the name of your connector from the Visual Studio Connected Service step (your first name last name connector)** in the search field and hit **Enter**

    ![AgentConnectorSearch.png](./images/instructions273634/AgentConnectorSearch.png)

1. You may have to scroll down in the list of connectors to find your results again. Click **Update Delivery Address** to begin adding this action to your agent

    ![AgentAddUpdate.png](./images/instructions273634/AgentAddUpdate.png)

1. Once the connector has loaded, in the End user authentication dropdown, select **Copilot author authentication** then click **Next**

    ![ActionUpdateAuth.png](./images/instructions273634/ActionUpdateAuth.png)

1. On the Inputs and Outputs screen, click **Next** again.

    ![UpdateNextInput.png](./images/instructions273634/UpdateNextInput.png)

1. Click **Finish** to complete adding the plugin to the agent

    ![UpdateFinish.png](./images/instructions273634/UpdateFinish.png)

1. Confirm that you see both the **Get items** and **Update delivery** actions in the list of items on the Actions screen

    ![ConfirmActions.png](./images/instructions273634/ConfirmActions.png)

1. Return to Visual Studio and click the **Run** button next to the HTTPS flag to run your application in HTTPS

    ![step68.jpg](./images/instructions273634/step68.jpg)

1. Click **Yes** on the **Microsoft Visual Studio** dialog to trust the IIS Express SSL certificate.

    ![step71.jpg](./images/instructions273634/step71.jpg)

1. Click **Yes** on the final security warning dialog to install the IIS cert

    ![step72.jpg](./images/instructions273634/step72.jpg)

1. Once the application is running a new browser window will open with a warning that you are about to connect to a developer tunnel click **Continue** to open your running application in Microsoft edge

    ![step73.jpg](./images/instructions273634/step73.jpg)

1. With your application running return to Microsoft Copilot Studio in the **Test Copilot** pane click the Map button on the right to open the conversation map console

    ![step74.jpg](./images/instructions273634/step74.jpg)

1. Now you can test your Copilot's new capabilities and see in real time how it is making calls to the plugins you just added. Enter +++What's my order details?+++ and click **send**

    ![AgentGetTest.png](./images/instructions273634/AgentGetTest.png)

1. An **Activity Map** pane should pop up. This is where you can see how your agent is pulling together the actions needed to complete your request. However, as you have not provided an order number to make the call to the service it has formulated a response to ask you for the missing details

    ![AgentGetTestConvoMap.png](./images/instructions273634/AgentGetTestConvoMap.png)

1. Enter an order number and click **send**

    ![step77.jpg](./images/instructions273634/step77.jpg)

    You'll see the order number is passed to the actions and the results are returned to your agent

    ![AgentGetMapFilled.png](./images/instructions273634/AgentGetMapFilled.png)

1. Click the reset button to start a new test session

    ![step79.jpg](./images/instructions273634/step79.jpg)

1. Enter +++Update my delivery address for order 123456 to 1 Microsoft Way, Redmond 98052 WA+++ and click send

    ![update-delivery-address.png](./images/instructions273634/update-delivery-address.png)

1. This time Copilot Studio will find the right action and it will be smart enough to fill all the address details in the right inputs as shown below

    ![AgentFinalTest.png](./images/instructions273634/AgentFinalTest.png)

Congratulations! That's it! You have successfully created a new agent and extended that using a custom connector! 

Nothing will be graded so feel free to submit and close out of the VM. If you finished the workshop you get an A+!
