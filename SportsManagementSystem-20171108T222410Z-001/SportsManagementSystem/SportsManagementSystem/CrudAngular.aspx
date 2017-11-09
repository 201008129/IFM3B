<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrudAngular.aspx.cs" Inherits="SportsManagementSystem.CrudAngular" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
            <style type="text/css">
        #tblContainer, #tblcollections, #tblCRUD, td {
            border: double;
        }

        th {
            background-color: darkgray;
        }

        #dvcollection {
            height: 500px;
            overflow-y: scroll;
        }
    </style>
    </title>


</head>

<body>
    <script src="js/angular.js"></script>
    <script src="js/ANGULAR_CRUD/angular-route.js"></script>
    <script src="js/ANGULAR_CRUD/AngularCrud.js"></script>

    <form id="form1" runat="server">
    <div>
    <h2>Using Angular for Performing CRUD Operations</h2>
<body>
    <table id="tblContainer" ng-app="ServiceApp" ng-controller="cntrl_Service">
        <tr>
            <td>
                <table id="tblCRUD">
                    <tr>
                        <td>
                            <span>EmpNo</span>
                        </td>
                        <td>
                            <input type="text" id="eno" readonly="readonly" ng-model="EmpNo"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>EmpName</span>
                        </td>
                        <td>
                            <input type="text" id="ename" required ng-model="EmpName" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>Salary</span>
                        </td>
                        <td>
                            <input type="text" id="salary" required ng-model="Salary" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>DeptName</span>
                        </td>
                        <td>
                            <input type="text" id="dname" required ng-model="DeptName" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>Designation</span>
                        </td>
                        <td>
                            <input type="text" id="desig" required ng-model="Designation" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="button" id="new" value="New" ng-click="clear()" />
                        </td>
                        <td>
                            <input type="button" id="save" value="Save" ng-click="save()" />
                        </td>
                        <td>
                            <input type="button" id="delete" value="Delete" ng-click="delete()" />
                        </td>
                    </tr>
                </table>
                <div>{{Message}}</div>
            </td>
            <td>
                <div id="dvcollection">
                    <table id="tblcollections">
                        <thead>
                            <tr>
                                <th>EmpNo</th>
                                <th>EmpName</th>
                                <th>Salary</th>
                                <th>DeptName</th>
                                <th>Designation</th>
                            </tr>
                        </thead>
                        <tbody ng-repeat="Emp in Employees">
                            <tr ng-click="get(Emp)">
                                <td> <span>{{Emp.EmpNo}}</span></td>
                                <td> <span>{{Emp.EmpName}}</span></td>
                                <td> <span>{{Emp.Salary}}</span></td>
                                <td> <span>{{Emp.DeptName}}</span></td>
                                <td> <span>{{Emp.Designation}}</span></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</body>
    </div>
    </form>
</body>
</html>


