# SoftwareArchitectAsssignment
This project is for technical test assignment 
To  run this project 
. restore database (TransactionData.bak under SQL foler)
. change database credential under appsetting.json file 
. run vs to see the project. (Can use sample xml file and csv file under SampleTemplate folder)

To import file
http://localhost:5000/Home

API endpoints : 
GetTransaction with multiple filters
http://localhost:5000/api/Transaction?currency=usd&fromDate=2019/01/02&toDate=2022/05/05&status=Approved

GetTransactionByCurrency
http://localhost:5000/api/Transaction/GetTransactionByCurrency?currency=USD

GetTransactionByStatus
http://localhost:5000/api/Transaction/GetTransactionBystatus?Status=Approved

GetTransactionByDateRange
http://localhost:5000/api/Transaction/GetTransactionBydaterange?fromdate=2019/01/01&todate=2019/02/20

Thank you!