#NimbusWebJob

## What is this?
This is small sample app that shows how to host [Nimubs](https://github.com/NimbusAPI/Nimbus) in a continous running [web job](http://www.hanselman.com/blog/IntroducingWindowsAzureWebJobs.aspx)

## Why would I want to do that?
Well the alternatives are to host in an web/worker role or a vm, however given the choice
> Web Sites is the best choice since it’s the simplest option and is fully-managed. The Web Sites platform is being constantly innovated on with new features surfacing almost every month – Microsoft are investing a lot of resources into making sure it’s a state of the art platform

[http://robdmoore.id.au/blog/2012/06/09/windows-azure-web-sites-vs-web-roles/](http://robdmoore.id.au/blog/2012/06/09/windows-azure-web-sites-vs-web-roles/)

## Projects

##### NimbusWebJob.MessageContracts
Defines the shared command and events types

##### NimbusWebJob.Web
MVC application showing a fictitious customer signup process to demonstrate publish an event on the bus using Nimbus

##### NimbusWebJob.WebJob
Console application that will host Nimbus and be deployed as a continous running WebJob

##### NimbusWebJob.WebJobHost
Rather than publishing NimbusWebJob.WebJob as a continous running webjob on its own, you can publish it as part of a website. 
I prefer this as you can use the website to show bus statistics such as queue / topics names and counts. This project is a demonstration of this.

## Running locally

1. [Install Service Bus for Windows Server](https://msdn.microsoft.com/en-us/library/dn282152.aspx)
2. Run `ResetTheWorld.bat` as an administrator. This will create a new service bus namespace named `nimbus-web-job` and create a new folder in your temp directory named `WEBJOBS_SHUTDOWN_FILE`

## References

http://blog.amitapple.com/post/74215124623/deploy-azure-webjobs/
Show how to deploy a Webiste with WebJobs by putting the webjob in a know folder with a specific name

http://blog.amitapple.com/post/2014/05/webjobs-graceful-shutdown/
Demonstrates how to handle a "graceful" shutdown process for a WebJob 
