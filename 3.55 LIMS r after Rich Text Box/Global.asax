<%@ Application Language="C#" %>
<script RunAt="server">
    
    void Session_Start(object sender, EventArgs e)
    {
        Session["personid"] = "";
        Session["DepId"] = "";
        Session["PersonName"] = "";
        Session["LoginID"] = "";
        Session["PrintVisitSlip"] = "";
        Session["dtServices"] = "";
        Session["ClinicId"] = "";
        Session["dt"] = "";
    }
</script>
