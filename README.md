# XPath-Injection-Lab

This Lab is for XPath Injection and its potential consequences, as well as insights into how to protect applications from this vulnerability. Let's explore the innovative techniques used to manipulate XPath queries and obtain valuable insights.

Below provided some basic steps for setting up a vulnerable lab instance that can be used to replicate the scenarios covered in this blog.

``git clone https://github.com/NetSPI/XPath-Injection-Lab.git``

``cd XPath-Injection-Lab``

``docker build -t bookapp . ``

``docker run -p 8888:80 bookapp``

Tip: We recommend yourself with how to work with login operators attempting this lab.

After hosting the vulnerable application, configure your browser to use an intercepting web proxy (like Burp Suite), and navigate to http://localhost:8888. Click on the “Find” button, as shown in the below screenshot, and intercept the request in your proxy. Satrt exploring XPath Injection in "title" paramter value. 

<img width="454" alt="image" src="https://github.com/NetSPI/XPath-Injection-Lab/assets/136427070/477d3064-c22b-4ad7-9eaf-c81c22bbb66f">


 
**Solution: https://github.com/NetSPI/XPath-Injection-Lab/blob/main/Solution.md**
