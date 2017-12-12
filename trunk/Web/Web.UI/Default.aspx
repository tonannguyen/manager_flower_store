﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Root.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web.UI.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

    <form id="form1" runat="server">

    <div class="right_col" role="main">
          <!-- top tiles -->
          <div class="row tile_count">
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Doanh thu ngày </span>
              <div><asp:Label ID="lblDay" runat="server" Text="123"  style="font-size: 20px;margin-left: 20px;"></asp:Label></div>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Doanh thu tuần trước</span>
              <div><asp:Label ID="lblLastWeek" runat="server" Text="123"   style="font-size: 20px;margin-left: 20px;"></asp:Label></div>
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-clock-o"></i> Doanh thu tháng trước </span>
              <div><asp:Label ID="lblLastMonth" runat="server" Text="123"   style="font-size: 20px;margin-left: 20px;"></asp:Label></div>
              
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Doanh thu quý trước </span>
              <div><asp:Label ID="lblQuarter" runat="server" Text="123"  style="font-size: 20px;margin-left: 20px;"></asp:Label></div>
              
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
              <span class="count_top"><i class="fa fa-user"></i> Doanh thu năm trước</span>
              <div><asp:Label ID="lblYear" runat="server" Text="123"  style="font-size: 20px;margin-left: 20px;"></asp:Label></div>
              
            </div>

          </div>
          <!-- /top tiles -->

          <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
              <div class="dashboard_graph">

                <div class="row x_title">
                  <div class="col-md-6">
                    <h3>Biểu Đồ Doanh Thu</h3>
                  </div>    
                </div>

                <div class="col-md-12 col-sm-9 col-xs-12">
                  <div id="chart_plot_01" class="demo-placeholder">
                  
                    </div>
                </div>
                <div class="clearfix"></div>
              </div>
            </div>

          </div>
          <br />
        </div>
</form>
</asp:Content>
