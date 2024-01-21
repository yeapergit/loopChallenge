# loopChallenge

Need to run API first (dotnet run in API root folder) and then Client (dotnet run in Client root folder)

# Questions

## After creating the API, walk us through the key steps and considerations you would take to set up this API, ensuring it's secure, scalable, and well-integrated with Azure services.

To make an API more secure we could add some type of authentication, for example OAUTH or Active Directory (Azure AD). We can also use HTTPS to a more secure communication.
In terms of scalability we can use something like Kubernetes (AKS for Azure) because it can create new pods based on the load of API. 
We can also use a load-balancer to share the load from the multiple pods of the Service. 
It is also important to make Performance Tests to make sure what kind of traffic/load our API can handle.


## Follow us through the steps you would take to construct a pipeline for this API, ensuring a smooth and automated deployment process. Consider aspects such as version control integration, automated testing, and deployment to Azure resources.

To have a version control integration I would choose something like gitlab, so I can manage the Reviews and Merges and release versions based on hotfixes, improvements or any kind of change. 
In terms of pipeline I would make some steps for example:
- Get last code version from repository
- Contract validation (lets assume that we create specs for our services)
- Build
- Integration Tests
- Unit tests
- SonarQube (for code quality)
- Artifact Packaging
- Deploy
