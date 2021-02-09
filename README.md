# cic-whiteboard-app

So this went horribly wrong. I realize I was too ambitious and at some point down the road completely lost track of time. The result is a bunch of unfinished and poorly implemented user stories.

Initially I wanted to use SignalR along with the HTML drag and drop API to create a live whiteboard experience in which you could drag post-it notes around.
Somehow I thought I would have plenty of time to do this AFTER creating a REST API and some basic Angular UI. But 8 hours is apparently no time at all.

I decided to use Azure AD for authentication, as I have done this a few times before in earlier projects, and I thought I could save some time and get a bunch of the user stories for free.

I hindsigt it was bad idea, as I have wasted time configuring instead of implementing features.

You can sign in with either of two accounts which are registered on Azure AD:

account: Bertha@cicwhiteboard@onmicrosoft.com   pw: Wucu4793

account: Sam@cicwhiteboard@onmicrosoft.com      pw: Salu4705

To run the app:
-> cd cic-whiteboard-app
-> dotnet run

The app has also been deployed to azure:
https://cicwhiteboardapp20210209022915.azurewebsites.net/whiteboard
