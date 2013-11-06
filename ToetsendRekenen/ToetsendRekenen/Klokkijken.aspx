<%@ Page Title="" Language="C#" MasterPageFile="~/MasterToetsendRekenen.Master" AutoEventWireup="true" CodeBehind="Klokkijken.aspx.cs" Inherits="ToetsendRekenen.WebForm14" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link rel="stylesheet" type="text/css" href="Klokkijken.css" />
    <script type="text/javascript" src="http://jqueryrotate.googlecode.com/svn/trunk/jQueryRotate.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //vraag
            $('#langeWijzerVraag').rotate(360 / 60 * parseInt("<%= minutenVanLangewijzer%>"));
            $('#korteWijzerVraag').rotate(360 / 60 * parseInt("<%= minutenVanKortewijzer%>"));

            //antwoorden
            $('#AnswerLangeWijzer1').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanLangewijzer1%>"));
            $('#AnswerKorteWijzer1').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanKortewijzer1%>"));

            $('#AnswerLangeWijzer2').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanLangewijzer2%>"));
            $('#AnswerKorteWijzer2').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanKortewijzer2%>"));

            $('#AnswerLangeWijzer3').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanLangewijzer3%>"));
            $('#AnswerKorteWijzer3').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanKortewijzer3%>"));

            $('#AnswerLangeWijzer4').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanLangewijzer4%>"));
            $('#AnswerKorteWijzer4').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanKortewijzer4%>"));

            $clockVisibility = ("<%= clockVisibility%>");
            $answerClockVisibility = ("<%= answerClockVisibility%>");

            if ($clockVisibility === "False") {
                $('#wijzerPlaatVraag').css("visibility", "hidden");
                $('#korteWijzerVraag').css("visibility", "hidden");
                $('#langeWijzerVraag').css("visibility", "hidden");
            }
            else {
                $('#wijzerPlaatVraag').css("visibility", "visible");
                $('#korteWijzerVraag').css("visibility", "visible");
                $('#langeWijzerVraag').css("visibility", "visible");
            }

            if ($answerClockVisibility === "False") {
                $('.AnswerWijzerPlaat').css("visibility", "hidden");
                $('.AnswerKorteWijzer').css("visibility", "hidden");
                $('.AnswerLangeWijzer').css("visibility", "hidden");
            }
            else {
                $('.AnswerWijzerPlaat').css("visibility", "visible");
                $('.AnswerKorteWijzer').css("visibility", "visible");
                $('.AnswerLangeWijzer').css("visibility", "visible");
            }
                 
            });
        
        function setAnswerclocksAfterRBLselection() {
            $('#AnswerLangeWijzer1').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanLangewijzer1%>"));
            $('#AnswerKorteWijzer1').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanKortewijzer1%>"));

            $('#AnswerLangeWijzer2').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanLangewijzer2%>"));
            $('#AnswerKorteWijzer2').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanKortewijzer2%>"));

            $('#AnswerLangeWijzer3').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanLangewijzer3%>"));
            $('#AnswerKorteWijzer3').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanKortewijzer3%>"));

            $('#AnswerLangeWijzer4').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanLangewijzer4%>"));
            $('#AnswerKorteWijzer4').rotate(360 / 60 * parseInt("<%= AnswerMinutenVanKortewijzer4%>"));
        }

        
                    
    </script>
                    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="sommenContent">
        
        <div class="som">
            
            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold;"><asp:Label ID="lblCategorie" runat="server" Text=""></asp:Label></span><br />
            <br />
            Wat is de tijd van de klok?<br />
            <br />
            06 : 00 uur t/m 17 : 59 uur is dag.<br />
            18 : 00 uur t/m 05 : 59 uur is nacht.<br />
            <br />
            <div id="questionClock" runat="server">
                <asp:Label ID="digitalClock" runat="server" Text=""></asp:Label>
                <img id="wijzerPlaatVraag" class="wijzerPlaat" src="Images/WijzerPlaat.png" />
                <img id="korteWijzerVraag" class="korteWijzer" src="Images/KorteWijzer.png" />
                <img id="langeWijzerVraag" class="langeWijzer" src="Images/LangeWijzer.png" />
                <asp:Image ID="imgSunAndMoon" CssClass="SunAndMoon" ImageUrl="Images/Sun.png" runat="server" />
            </div>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    
            <asp:RadioButtonList ID="RblAntwoorden" CssClass="rblAntwoorden" repeatdirection="Vertical"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="RblAntwoorden_SelectedIndexChanged">
                <asp:ListItem>
                    <img id="AnswerWijzerPlaat1" class="AnswerWijzerPlaat" src="Images/WijzerPlaat.png" />
                    <img id="AnswerKorteWijzer1" class="AnswerKorteWijzer" src="Images/KorteWijzer.png" />
                    <img id="AnswerLangeWijzer1" class="AnswerLangeWijzer" src="Images/LangeWijzer.png" />
                </asp:ListItem>
                <asp:ListItem>
                    <img id="AnswerWijzerPlaat2" class="AnswerWijzerPlaat" src="Images/WijzerPlaat.png" />
                    <img id="AnswerKorteWijzer2" class="AnswerKorteWijzer" src="Images/KorteWijzer.png" />
                    <img id="AnswerLangeWijzer2" class="AnswerLangeWijzer" src="Images/LangeWijzer.png" />
                </asp:ListItem>
                <asp:ListItem>
                    <img id="AnswerWijzerPlaat3" class="AnswerWijzerPlaat" src="Images/WijzerPlaat.png" />
                    <img id="AnswerKorteWijzer3" class="AnswerKorteWijzer" src="Images/KorteWijzer.png" />
                    <img id="AnswerLangeWijzer3" class="AnswerLangeWijzer" src="Images/LangeWijzer.png" />
                </asp:ListItem>
                <asp:ListItem>
                    <img id="AnswerWijzerPlaat4" class="AnswerWijzerPlaat" src="Images/WijzerPlaat.png" />
                    <img id="AnswerKorteWijzer4" class="AnswerKorteWijzer" src="Images/KorteWijzer.png" />
                    <img id="AnswerLangeWijzer4" class="AnswerLangeWijzer" src="Images/LangeWijzer.png" />
                </asp:ListItem>
            </asp:RadioButtonList>
                    <div id="spacer" runat="server"></div>
            <br />
            <asp:Label ID="LblGoedFout" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnVolgendeVraag" runat="server" Text="Volgende vraag" OnClick="btnVolgendeVraag_Click" BackColor="#3333FF" ForeColor="White" />
                 </ContentTemplate>
            </asp:UpdatePanel>

            

            <br />
        </div>
        <div class="uitkomstSterren">
            <div class="sterren">
                
                <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; position:absolute; top:15px; margin-left:30px; left: 623px;">Score</span>
                <span class="SterImages">
                <asp:Image ID="imgSter1" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter2" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter3" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter4" ImageUrl="Images/legeSter.png" runat="server" /><asp:Image ID="imgSter5" ImageUrl="Images/legeSter.png" runat="server" />
                </span>
                <div class="voortgang"><span id="voortgang" style="font-family: Arial, Helvetica, sans-serif; font-size: 19px; font-weight: bold; background-color: #FFFF00">Voortgang <asp:Label ID="lbVoortgang" runat="server" Text="0"></asp:Label>/50 vragen</span></div>

            </div>
            <br />
            <span style="font-family: Arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold">Uitleg</span><br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div runat="server" id="divUitleg">
                        
                    </div>
                    <asp:Label ID="lblUitlegAntwoord" runat="server" Text="Label"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />

            
            
        </div>
    </div>

    
</asp:Content>
