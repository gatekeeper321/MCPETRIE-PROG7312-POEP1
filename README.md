# MCPETRIE - ST10263164 -  PROG7312

## How to open project

- Open Visual Studio 2022 
- Select/click Clone repository in the upper right corner of the IDE 
- You will be asked to enter a Git repository URL 
- Navigate to this project’s online GitHub repository link 
- There you will be able to see a green “Code” button in the upper middle section, select the drop-down menu for it 
- Click “Copy URL to Clipboard” 
- Enter the Git URL containing *.git into the prompt from the IDE 

## How to run project

- After completing the previous step, you can proceed to running the project 
- Run either with or without debugging 
- To view what was added in this portion of the POE proceed to views: 
  - “Service Request Status List” - to view sample data to use in the next view I will mention 
    - Contains a simple list of Reports 
  - “Service Request Status Search” - to view what was done using a Binary search tree, graph and graph traversal
    - Contains search option for the user to enter a report ID 
    - Binary Search Tree is used to quickly find entered ID 
    - Graph and graph traversal is also used to get list of reports that are in the same location as entered report ID, that have a higher priority category and are to be completed before       it 

## Data Structures
### Binary Search Tree
The Binary Search Tree (BTS) was used for a quick search of report IDs. The BTS, like the linked list like done in part 1, makes use of parent/child nodes, however instead of having head or tail nodes it has left and right nodes (GeeksforGeeks, 2025). This allows the search to be performed quickly as if structured correctly; the BTS will look like the root system of a tree or a pyramid.  There will be one main root (node) at the top, and each layer down will double. The Binary search tree is essentially cutting time down by just checking if the value it is searching for is higher or lower than this current number in the tree and then goes either left or right based on that decision. Doing this removes the need for iterating through every value in a list and cuts search time dramatically. 
### Graph & Graph Traversal
Graph data structures are traditionally non-linear and are made using vertices and edges (GeeksforGeeks, 2025). Vertices (nodes) and Edges (lines) are used to create relationships in the graph with nodes being the data and lines being the link between them. 

The Graph in my project was used to create a relationship between the report categories and report location, this allows multiple reports within the same location to be linked together based on a hierarchy of categories with the idea being certain categories were more urgent than others and were to be dealt with first before moving onto the next report 

Category hierarchy shown below: 

Sanitation > Electricity > Roads > Other 

Graph Traversal is then used to get the dependencies between the reports, so if report 11 and 12 were in the same location but report 12 had its category as Electricity and report 11 had its category Sanitation, report 11 would appear in below report 12 as one of its dependencies as it is more vital and needs to be completed for the municipality can think about moving on to report 12. 

This hierarchy could be changed in the future to include more categories or to reorder the categories to create a less linear shape. 

## Youtube:
https://youtu.be/TIYKFVPsbhw

## References
GeeksforGeeks, (2025). Binary Search Tree – Data Structure. [online] Available at: https://www.geeksforgeeks.org/dsa/binary-search-tree-data-structure/ (Accessed 13 November 2025).  

GeeksforGeeks, (2025). Graph and its Representations. [online] Available at: https://www.geeksforgeeks.org/dsa/graph-and-its-representations/ (Accessed 13 November 2025).  

BDRShield, (2023). Microsoft Azure Scalability: Features and Functionality. [online] Available at: https://www.bdrshield.com/blog/azure-scalability-features-and-functionality/ (Accessed 13 November 2025). 

BrowserStack, (2024). Top 17 Website Launch Checklist: The Essentials. [online] Available at: https://www.browserstack.com/guide/website-launch-checklist (Accessed 13 November 2025). 

 GitHub Copilot (2024) Chat-based programming assistance. Microsoft, Visual Studio IDE. Available at: https://copilot.microsoft.com/ (Accessed: 10 September 2025).   

OpenAI (2025) ChatGPT (GPT-5) [AI language model]. Available at: https://chat.openai.com/ (Accessed: throughout project).  

Microsoft (2024) System.Collections.Generic.HashSet class. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=netframework-4.7.2 (Accessed: 15 October 2025). Microsoft (2024)  

 System.Collections.Generic.Dictionary<TKey,TValue> class. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netframework-4.7.2 (Accessed: 14 October 2025).  

Jamro, M. (2024) C# Data Structures And Algorithms. 2nd ed. Birmingham: Packt Publishing Ltd. 
