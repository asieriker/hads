<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="AzureCloudServiceEn4" generation="1" functional="0" release="0" Id="46bb8fb4-9219-46c0-b34f-3cb14fe6b459" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="AzureCloudServiceEn4Group" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="WebServiceEn35:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/AzureCloudServiceEn4/AzureCloudServiceEn4Group/LB:WebServiceEn35:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="WebServiceEn35:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/AzureCloudServiceEn4/AzureCloudServiceEn4Group/MapWebServiceEn35:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="WebServiceEn35Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/AzureCloudServiceEn4/AzureCloudServiceEn4Group/MapWebServiceEn35Instances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:WebServiceEn35:Endpoint1">
          <toPorts>
            <inPortMoniker name="/AzureCloudServiceEn4/AzureCloudServiceEn4Group/WebServiceEn35/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapWebServiceEn35:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/AzureCloudServiceEn4/AzureCloudServiceEn4Group/WebServiceEn35/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapWebServiceEn35Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/AzureCloudServiceEn4/AzureCloudServiceEn4Group/WebServiceEn35Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="WebServiceEn35" generation="1" functional="0" release="0" software="C:\Users\iker5\Desktop\2CUATRI\HADS\lab2\lab2_\AzureCloudServiceEn4\csx\Release\roles\WebServiceEn35" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;WebServiceEn35&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;WebServiceEn35&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/AzureCloudServiceEn4/AzureCloudServiceEn4Group/WebServiceEn35Instances" />
            <sCSPolicyUpdateDomainMoniker name="/AzureCloudServiceEn4/AzureCloudServiceEn4Group/WebServiceEn35UpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/AzureCloudServiceEn4/AzureCloudServiceEn4Group/WebServiceEn35FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="WebServiceEn35UpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="WebServiceEn35FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="WebServiceEn35Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="a8cc8305-1acf-44c8-bb0d-60ad2184e343" ref="Microsoft.RedDog.Contract\ServiceContract\AzureCloudServiceEn4Contract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="0e6bac83-223a-407f-8d41-45ec7de58571" ref="Microsoft.RedDog.Contract\Interface\WebServiceEn35:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/AzureCloudServiceEn4/AzureCloudServiceEn4Group/WebServiceEn35:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>