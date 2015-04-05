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
2. Run `ResetTheWorld.bat` as an administrator. This will create a new service bus namespace named `nimbus-web-job` and create a new folder in your temp directory named `WEBJOBS_SHUTDOWN_FILE` used to handle graceful shutdown of the webjob (see references below)
3. Set startup project to `NimbusWebJob.Web`, `NimbusWebJob.WebJob`, `NimbusWebJob.WebJobHost` and run
4. As you signup customers you will see the WebJob processing them via the console output (you can also install [seq](http://getseq.net/) to see the logs)
5. If you close the WebJob, signup a few customers and then refresh the home page of the WebJobHost, you should see the active message count increase as the message remain on the queue unprocessed.

## Deploying to Azure
1. Create a new azure web site (enabling 'Always On', see reference below) and using your favourite deployment method, deploy the `NimbusWebJob.WebJobHost` project there. This project has [octopack](http://docs.octopusdeploy.com/display/OD/Using+OctoPack) installed and a custom nuspec file to ensure the WebJob is packaged with the website)
2. If you go the azure portal and click on the website, you should see the WebJob in the webjobs blade. From there you can view the logs to see all the console output.

## References

[http://blog.amitapple.com/post/74215124623/deploy-azure-webjobs/](http://blog.amitapple.com/post/74215124623/deploy-azure-webjobs/)

Show how to deploy a Webiste with WebJobs by putting the webjob in a know folder with a specific name. In this case there is a post build step that copies the output of `NimbusWebJob.WebJob` to the correct directory in `NimbusWebJob.WebJobHost`

[http://blog.amitapple.com/post/2014/05/webjobs-graceful-shutdown/](http://blog.amitapple.com/post/2014/05/webjobs-graceful-shutdown/)

Demonstrates how to handle a "graceful" shutdown process for a WebJob

[http://blogs.msdn.com/b/mschray/archive/2015/03/31/webjob-not-running-consistently.aspx](http://blogs.msdn.com/b/mschray/archive/2015/03/31/webjob-not-running-consistently.aspx)

For continuous WebJobs, it is recommended that you enable Always On for your web app. The Always On feature, available in Basic and Standard mode, prevents web apps from being unloaded, even if they have been idle for some time. If your web app is always loaded, your continuously running WebJob may run more reliably.
