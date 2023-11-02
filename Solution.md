1. Finding the Length of the Root Node's Name

The "root node" refers to the highest node in the XML document hierarchy. It means identifying the starting point of an XPath expression within an XML document. XPath expressions are used to navigate through elements and attributes in an XML document, and specifying the root node provides the context from which the navigation begins. By utilizing the string-length() function, we can determine the length of the root node's name. This fundamental step allows us to better craft subsequent payloads. Testing different lengths numbers, we can ascertain that the root node's length is 5 characters.

Payload: 

``' or string-length(name(/*)) < 0 or '``

 ![image](https://github.com/NetSPI/XPath-Injection-Lab/assets/136427070/78e2c961-5b5c-4c58-b6a5-6ad4511b1797)



Observe that the application's content length changes in response to a request of 6. which means the root node's length is 5.
 



2. Extracting Characters from the Root Node's Name

We use the starts-with() method to get characters from the name of the root node. Using Burp's Intruder function with the cluster bomb attack type, we can determine the name of the parent node is ‘Books’.

Payload: 

``' or starts-with(name(/*), 'AAAAA') or '``
![image](https://github.com/NetSPI/XPath-Injection-Lab/assets/136427070/45802cd4-982b-4ce8-8da5-dde74be3f762)

With the cluster bomb attack type to determine the name of the root node. Observe that the application response content length changes on the "Books" character combination.  


 
3. Counting the number of nodes beneath the root node.

The count() function helps us determine the number of elements beneath the root node. This insight allows us to comprehend the structure of the XML database, paving the way for more targeted queries.

Payload: 

``' or count(/*[1]/*)<0 or '``

1.	“ Or “ This is a logical OR operator in XPath. It is used to combine two conditions, and the expression evaluates to true if either of the conditions is true.
2.	“ count(/*[1]/*) “ This part of the expression calculates the count of child elements of the first child of the root node of the XML document. “ /* “ selects the root node, “ [1] “ selects its first child, and “ /* “ selects all the child elements of the first child.
3.	“ <0 “ This is a numerical comparison, checking if the count calculated in the previous step is less than 0.

![image](https://github.com/NetSPI/XPath-Injection-Lab/assets/136427070/53c50a56-96fc-47b7-a427-a99e92a3943c)
Please observe that the application's content length changes in response to a request of 5. which means the node name beneath root node’s length is less than 5, meaning its length is 4.
 


4. Extracting the name of node beneath the root node. 

We use the starts-with() method to get characters from the name of the node and extract the name of node beneath the root node.

Payload: 

``' or starts-with(name(/*[1]/*), 'AAAA') or '``

![image](https://github.com/NetSPI/XPath-Injection-Lab/assets/136427070/bf53b4de-cae3-4798-83aa-5b5b6e67af1e)

 
