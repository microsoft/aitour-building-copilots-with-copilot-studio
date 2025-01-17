# 5 - Adding Connector To Microsoft Copilot Studio

With the connector built and the new post method added it's time to add this to Microsoft Copilot Studio so it can be used by the Generative Actions engine.

1. Before publishing the connector, we need to change the run mode from http back to https, click the arrow next to **http** and select **https**

    ![step45.jpg](./images/instructions273634/step45.jpg)

1. In the solution explorer on the right side, **Right click>Connected Services>Add>Microsoft Power Platform**

    ![step46.jpg](./images/instructions273634/step46.jpg)

1. In the top right of the **Connect to Microsoft Power Platform** dialog click **Sign in>Work, School or personal account** then use your tenant credentials to login to connect to the Power Platform.

    **Username:** +++@lab.CloudCredential(CSBatch1).UserPrincipalName+++


    **Password:** +++@lab.CloudCredential(CSBatch1).Password+++
        
    **Temporary Access Password:** +++@lab.Variable(TAP)+++

    ![step47.jpg](./images/instructions273634/step47.jpg)

1. Check to make sure the **AI Roadshow (default)** environment is selected and that the **Common Data Services Default Solution** is selected then click the **Plus(+)** button to create a new custom connector

    ![AgentsVSConnectService.png](./images/instructions273634/AgentsVSConnectService.png)

1. Accept the **Power Platform environment**. Update the **Custom connector name** to **Your First and Last Name Plus the word Connector**, for example, Jane Doe Connector. Then click **Create**. It's very important to remember this name as you'll need to reference this in later steps!

    ![AgentsVSAddConnector.png](./images/instructions273634/AgentsVSAddConnector.png)

1. Next, you're going to create a Dev Tunnel so you can test your Connector. Click the **Plus (+)** button to create a public dev tunnel which will allow you to debug the connector when it's called from our agent

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
