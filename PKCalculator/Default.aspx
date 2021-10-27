<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PKCalculator._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 674px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Pension Calculator<br />
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                    Your age&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="Age" runat="server">30</asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Your Salary&nbsp;&nbsp; 
                    <asp:TextBox ID="Salary" runat="server">90000</asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Pensionskasse A</td>
                <td>
                    Pensionskasse B</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:ObjectDataSource ID="PensionPlans" runat="server" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GeneratePensionPlans" TypeName="PKCalculator.PensionPlanSource">
                    </asp:ObjectDataSource>
                    <asp:DropDownList ID="PensionPlanA" runat="server" AutoPostBack="True" 
                        DataSourceID="PensionPlans" DataTextField="FullName" DataValueField="FullName">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="PensionPlanB" runat="server" AutoPostBack="True" 
                        DataSourceID="PensionPlans" DataTextField="FullName" DataValueField="FullName">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Pension Plan Details</td>
                <td>
                    Pension Plan Details</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="PlanADetails" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="StartAge" HeaderText="StartAge" 
                                SortExpression="StartAge" />
                            <asp:BoundField DataField="EndAge" HeaderText="EndAge" 
                                SortExpression="EndAge" />
                            <asp:BoundField DataField="EmployeePercentage" HeaderText="Employee %" 
                                SortExpression="EmployeePercentage" />
                            <asp:BoundField DataField="EmployerPercentage" HeaderText="Employer %" 
                                SortExpression="EmployerPercentage" />
                            <asp:BoundField DataField="EmployeeRiskPercentage" HeaderText="Employee Risk %" 
                                SortExpression="EmployeeRiskPercentage" />
                            <asp:BoundField DataField="EmployerRiskPercentage" HeaderText="Employer Risk %" 
                                SortExpression="EmployerRiskPercentage" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="PlanADetails" runat="server" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetPensionPlanDetails" TypeName="PKCalculator.PensionPlanSource">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="PensionPlanA" Name="identifier" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td>
                    <asp:GridView ID="PlanBDetails" runat="server" AutoGenerateColumns="False" 
                        DataSourceID="PensionPlanDetailsB" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="StartAge" HeaderText="StartAge" 
                                SortExpression="StartAge" />
                            <asp:BoundField DataField="EndAge" HeaderText="EndAge" 
                                SortExpression="EndAge" />
                            <asp:BoundField DataField="EmployeePercentage" HeaderText="Employee %" 
                                SortExpression="EmployeePercentage" />
                            <asp:BoundField DataField="EmployerPercentage" HeaderText="Employer %" 
                                SortExpression="EmployerPercentage" />
                            <asp:BoundField DataField="EmployeeRiskPercentage" HeaderText="Employee Risk %" 
                                SortExpression="EmployeeRiskPercentage" />
                            <asp:BoundField DataField="EmployerRiskPercentage" HeaderText="Employer Risk %" 
                                SortExpression="EmployerRiskPercentage" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="PensionPlanDetailsB" runat="server" 
                        OldValuesParameterFormatString="original_{0}" 
                        SelectMethod="GetPensionPlanDetails" TypeName="PKCalculator.PensionPlanSource">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="PensionPlanB" Name="identifier" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="CalculateButton" runat="server" onclick="CalculateButton_Click" 
            Text="Calculate" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="ErrorLabel" runat="server" 
            style="font-weight: 700; color: #FF0000"></asp:Label>
        <br />
        <table class="style1">
            <tr>
                <td>
                    <asp:DetailsView ID="CalculationA" runat="server" AutoGenerateRows="False" 
                        DataSourceID="CalculationResultsA" EnableModelValidation="True" Height="50px" 
                        Width="125px">
                        <Fields>
                            <asp:BoundField DataField="CoordinationDeduction" HeaderText="Coordination Amount" 
                                ReadOnly="True" SortExpression="CoordinationDeduction" />
                            <asp:BoundField DataField="CurrentYearSaved" HeaderText="CurrentYearSaved" 
                                ReadOnly="True" SortExpression="CurrentYearSaved" />
                            <asp:BoundField DataField="CurrentYearMonthlySalaryDeduction" 
                                HeaderText="CurrentYearMonthlySalaryDeduction" ReadOnly="True" 
                                SortExpression="CurrentYearMonthlySalaryDeduction" />
                            <asp:BoundField DataField="CurrentYearEmployee" 
                                HeaderText="CurrentYearEmployee" SortExpression="CurrentYearEmployee" />
                            <asp:BoundField DataField="CurrentYearEmployer" 
                                HeaderText="CurrentYearEmployer" SortExpression="CurrentYearEmployer" />
                            <asp:BoundField DataField="CurrentYearEmployeeRisk" 
                                HeaderText="CurrentYearEmployeeRisk" SortExpression="CurrentYearEmployeeRisk" />
                            <asp:BoundField DataField="CurrentYearEmployerRisk" 
                                HeaderText="CurrentYearEmployerRisk" SortExpression="CurrentYearEmployerRisk" />
                            <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" 
                                SortExpression="Total" />
                            <asp:BoundField DataField="TotalEmployee" HeaderText="TotalEmployee" 
                                SortExpression="TotalEmployee" />
                            <asp:BoundField DataField="TotalEmployer" HeaderText="TotalEmployer" 
                                SortExpression="TotalEmployer" />
                            <asp:BoundField DataField="TotalEmployeeRisk" HeaderText="TotalEmployeeRisk" 
                                SortExpression="TotalEmployeeRisk" />
                            <asp:BoundField DataField="TotalEmployerRisk" HeaderText="TotalEmployerRisk" 
                                SortExpression="TotalEmployerRisk" />
                        </Fields>
                    </asp:DetailsView>
                    <asp:ObjectDataSource ID="CalculationResultsA" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="CalculatePension" 
                        TypeName="PKCalculator.Calculator">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="Age" Name="age" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="Salary" Name="salary" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="PensionPlanA" Name="plan" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
                <td>
                    <asp:DetailsView ID="CalculationB" runat="server" AutoGenerateRows="False" 
                        DataSourceID="CalculationResultsB" EnableModelValidation="True" Height="50px" 
                        Width="125px">
                        <Fields>
                            <asp:BoundField DataField="CoordinationDeduction" HeaderText="Coordination Amount" 
                                ReadOnly="True" SortExpression="CoordinationDeduction" />
                            <asp:BoundField DataField="CurrentYearSaved" HeaderText="CurrentYearSaved" 
                                ReadOnly="True" SortExpression="CurrentYearSaved" />
                            <asp:BoundField DataField="CurrentYearMonthlySalaryDeduction" 
                                HeaderText="CurrentYearMonthlySalaryDeduction" ReadOnly="True" 
                                SortExpression="CurrentYearMonthlySalaryDeduction" />
                            <asp:BoundField DataField="CurrentYearEmployee" 
                                HeaderText="CurrentYearEmployee" SortExpression="CurrentYearEmployee" />
                            <asp:BoundField DataField="CurrentYearEmployer" 
                                HeaderText="CurrentYearEmployer" SortExpression="CurrentYearEmployer" />
                            <asp:BoundField DataField="CurrentYearEmployeeRisk" 
                                HeaderText="CurrentYearEmployeeRisk" SortExpression="CurrentYearEmployeeRisk" />
                            <asp:BoundField DataField="CurrentYearEmployerRisk" 
                                HeaderText="CurrentYearEmployerRisk" SortExpression="CurrentYearEmployerRisk" />
                            <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" 
                                SortExpression="Total" />
                            <asp:BoundField DataField="TotalEmployee" HeaderText="TotalEmployee" 
                                SortExpression="TotalEmployee" />
                            <asp:BoundField DataField="TotalEmployer" HeaderText="TotalEmployer" 
                                SortExpression="TotalEmployer" />
                            <asp:BoundField DataField="TotalEmployeeRisk" HeaderText="TotalEmployeeRisk" 
                                SortExpression="TotalEmployeeRisk" />
                            <asp:BoundField DataField="TotalEmployerRisk" HeaderText="TotalEmployerRisk" 
                                SortExpression="TotalEmployerRisk" />
                        </Fields>
                    </asp:DetailsView>
                    <asp:ObjectDataSource ID="CalculationResultsB" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="CalculatePension" 
                        TypeName="PKCalculator.Calculator">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="Age" Name="age" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="Salary" Name="salary" PropertyName="Text" 
                                Type="String" />
                            <asp:ControlParameter ControlID="PensionPlanB" Name="plan" 
                                PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
    <p>
        Anleitung:</p>
    <p>
        CurrentYear Werte beziehen sich aufs aktuelle Jahr, Total = Totalbetrag bis zur 
        Pension (mit 65 gerechnet)</p>
    <p>
        Risikobeiträge sind wie andere Versicherungsbeiträge - davon kriegt ihr was wenn 
        ihr krank oder invalid werdet - es zählt nicht zum Altersguthaben.</p>
    <p>
        Total = euer Altersguthaben bei der Pension (ohne Berücksichtigung der 
        Verzinsung).</p>
    <p>
        Bei PK Auswahl wird automatisch neu berechnet. Bei Änderungen am Alter / Salär 
        muss Calculate gedrückt werden.</p>
</body>
</html>
