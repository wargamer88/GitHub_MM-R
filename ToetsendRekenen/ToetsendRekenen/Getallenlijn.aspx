<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Getallenlijn.aspx.cs" Inherits="ToetsendRekenen.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>$(function () {
    var canvas = $('canvas')[0];
    var ctx = canvas.getContext('2d');

    var w = canvas.width = 700;
    var h = canvas.height = 400;
    with (ctx) {
        fillStyle = '#000';
        fillRect(0, 0, w, h);
        fill();
        beginPath();
        lineWidth = 2;
        strokeStyle = '#f00';
        moveTo(w / 7, h / 2);
        lineTo(6 * w / 7, h / 2);
        stroke();
        for (var i = -10; i <= 10; i++) {
            beginPath();
            strokeStyle = '#0f0';
            lineWidth = 2;
            moveTo(w / 2 + i * 20, h / 2 - 20);
            lineTo(w / 2 + i * 20, h / 2 + 20);
            fillStyle = '#ff0';
            fillText(i, (w / 2 + i * 20) - 5, h / 2 + 35);
            if (!i) {
                lineWidth = 4;
                strokeStyle = '#f0f';
            }
            fill();
            stroke();
        }
    }
});</script>

</asp:Content>
