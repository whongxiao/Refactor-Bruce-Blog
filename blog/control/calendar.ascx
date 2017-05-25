<%@ Control Language="C#" AutoEventWireup="true" CodeFile="calendar.ascx.cs" Inherits="contorl_calendar" %>

<DIV class="widget calendar" id=widgetd1a7eb03-6194-445c-ac9f-e018be7b9a11>

    <H4>Calendar</H4>
<DIV class=content>
<DIV style="TEXT-ALIGN: center">
<DIV id=calendarContainer>
<asp:calendar id="Calendar1" runat="server" CssClass=calendar Width="242px"  WeekendDayStyle-CssClass=weekend   TodayDayStyle-CssClass=today  SelectionMode="None" OtherMonthDayStyle-ForeColor="#cccccc" OnPreRender="Calendar1_PreRender" OnDayRender="Calendar1_DayRender"  DayNameFormat="Full"  CellSpacing="1" CellPadding="2" BorderColor="#aaaaaa">
    <TodayDayStyle Font-Bold="True"  CssClass="today"></TodayDayStyle>
    <NextPrevStyle ForeColor="red"></NextPrevStyle>
    <DayHeaderStyle ForeColor=white BackColor="red"></DayHeaderStyle>
    <WeekendDayStyle CssClass="weekend" />
    <OtherMonthDayStyle ForeColor="#CCCCCC" />
</asp:calendar>
</DIV>
</DIV></DIV></DIV>