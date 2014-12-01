<%@ Assembly Name="InfinityPartSample2" %>
<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CustomDonationDisplay.ascx.vb"
    Inherits="InfinityPartSample2.CustomDonationDisplay" %>
<%@ Import Namespace="InfinityPartSample2" %>
<asp:Label ID="lblError" runat="server" Font-Bold="true" ForeColor="red" />
<style type="text/css">
    .style1
    {
        width: 136px;
    }
    .style2
    {
        width: 335px;
    }
    .style3
    {
        width: 106px;
    }
    .divMessages
    {
        color: red;
        font-family: Tahoma;
        font-size: 9pt;
        border: 1pt solid #c0c0c0;
        padding: 5pt;
        font-weight: normal;
    }
</style>

<script language="javascript" type="text/javascript">

    function mySample2(pricePerFlop) {

        this.price = pricePerFlop;

        var me = this;  //preserve self reference w/in jquery funcs

        $(".QtySelect").change(function (e) {
            var amt = $(".QtySelect option:selected").val();
            amt = amt * me.price;  
            $(".TotalAmount").text("$" + amt);
        }).change();
    }


</script>
<asp:Panel ID="pnlForm" runat="server">
    <table style="width: 466px">
        <tr>
            <td colspan="2">
                <asp:Image CssClass="AlumniGiftImage" ID="imgHeading" runat="server" />
                <asp:Label ID="lblTitle" runat="server" Text="Alumni Flip Flop Drive" CssClass="BBFormTitle cdfTitle"></asp:Label>
                <hr />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="pnlMessage" runat="server" Visible="false" CssClass="divMessages">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Quantity (pairs):
            </td>
            <td class="style2">
                <asp:DropDownList ID="ddlQty" runat="server" CssClass="QtySelect">
                    <asp:ListItem Value="1" Text="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="2" Text="2"></asp:ListItem>
                    <asp:ListItem Value="3" Text="3"></asp:ListItem>
                    <asp:ListItem Value="4" Text="4"></asp:ListItem>
                    <asp:ListItem Value="5" Text="5"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:label ID="lblCaptionAmount" runat="server" Text="Amount"></asp:label>
            </td>
            <td class="TotalAmount">
            </td>
        </tr>
        <tr>
            <td class="style3">
                First name:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Last name:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Street address:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbStreet" runat="server" Width="127px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                City:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbCity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                State:
            </td>
            <td valign="top" class="style2">
                <asp:DropDownList ID="ddlStates" runat="server">
                </asp:DropDownList>
                &nbsp;Zip:
                <asp:TextBox ID="tbZip" runat="server" Width="62px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Email:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbEmail" runat="server" Width="193px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Phone:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbPhone" runat="server" Width="190px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;
            </td>
            <td class="style2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style3">
                Card type:
            </td>
            <td class="style2">
                <asp:DropDownList ID="ddCardType" runat="server">
                    <asp:ListItem Text="Visa" Value="2"></asp:ListItem>
                    <asp:ListItem Text="MasterCard" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Amex" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Diner's Club" Value="32"></asp:ListItem>
                    <asp:ListItem Text="Discover" Value="8"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Credit card no:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbCCNumber" runat="server" Width="246px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Card expires:
            </td>
            <td class="style2" valign="top">
                <asp:DropDownList ID="ddExpMonth" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                /
                <asp:DropDownList ID="ddExpYear" runat="server">
                    <asp:ListItem>2008</asp:ListItem>
                    <asp:ListItem>2009</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2015</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Card CSC:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbCSC" runat="server" Width="35px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Name on card:
            </td>
            <td class="style2">
                <asp:TextBox ID="tbCardHolder" runat="server" Width="245px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style3" valign="top">
                <td class="style2" valign="top">
                    <asp:CheckBox ID="cbPoor" Visible="false" runat="server" Text="Please put a dollar of my donation in the poor box." />
                </td>
            </td>
        </tr>
        <tbody runat="server" id="tbodyGiftNote" visible="false">
            <tr>
                <td class="style3" valign="top">
                    Gift Note:
                </td>
                <td class="style2" valign="top">
                    &nbsp;<asp:TextBox ID="tbSpecial" runat="server" TextMode="MultiLine" Columns="40"
                        Rows="4" Width="239px"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tbody id="tbodyTribute" runat="server" visible="false">
            <tr>
                <td class="style3">
                    Tribute to:
                </td>
                <td class="style2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style3">
                    First name:
                </td>
                <td class="style2">
                    <asp:TextBox ID="tbTribFName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Last name:
                </td>
                <td class="style2">
                    <asp:TextBox ID="tbTribLName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Tribute Description
                </td>
                <td class="style2">
                    <asp:TextBox ID="tbTribDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Tribute Type
                </td>
                <td class="style2">
                    <asp:TextBox ID="tbTribType" runat="server"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tr>
            <td class="style3">
                &nbsp;
            </td>
            <td class="style2">
                <asp:Button ID="btnDonate" runat="server" Text="Flip Out!" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel runat="server" ID="pnlThanks" Visible="false">
    <asp:Image runat="server" ID="imgThanks" Style="vertical-align: middle; margin-right: 10px;" />
    <asp:Label ID="lblThanks" runat="server" Text="Thanks for Flippin Out!"></asp:Label>
</asp:Panel>
