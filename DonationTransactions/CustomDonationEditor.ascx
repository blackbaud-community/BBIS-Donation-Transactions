<%@ Assembly Name="InfinityPartSample2" %>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CustomDonationEditor.ascx.vb"
    Inherits="InfinityPartSample2.CustomDonationEditor" %>
<%@ Import Namespace="InfinityPartSample2" %>
<asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="red" />
<%@ Register TagPrefix="bbnc" Namespace="BBNCExtensions.ServerControls" Assembly="BBNCExtensions" %>
<asp:Panel ID="pnlOptions" runat="server">
    <table>
        <tr>
            <td>
                Price per pair:
            </td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Designation:
            </td>
            <td>
                <bbnc:CFAPicker runat="server" ID="CFADesignationSelect" />
            </td>
        </tr>
        <tr>
            <td>
                Appeal:
            </td>
            <td>
                <bbnc:CFAPicker runat="server" ID="cfaAppealSelect" />
            </td>
        </tr>
        <tr>
            <td>
                Merchant Account:
            </td>
            <td>
                <asp:DropDownList ID="ddlMerchantAccounts" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
</asp:Panel>
<hr />
<div id="divHideMe" style="overflow: auto;">
    <bbnc:EmailEditor ID="EmailEditor1" runat="server"></bbnc:EmailEditor>
</div>
