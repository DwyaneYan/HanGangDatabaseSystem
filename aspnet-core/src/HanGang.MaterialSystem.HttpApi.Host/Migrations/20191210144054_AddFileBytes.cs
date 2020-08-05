using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HanGang.MaterialSystem.Migrations
{
    public partial class AddFileBytes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "DepthDecarburizationBytes",
                table: "Material_MetallographicDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "GrainSizeBytes",
                table: "Material_MetallographicDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "NonMetallicInclusionLevelBytes",
                table: "Material_MetallographicDataDetails",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "StructurBytes",
                table: "Material_MetallographicDataDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepthDecarburizationBytes",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "GrainSizeBytes",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "NonMetallicInclusionLevelBytes",
                table: "Material_MetallographicDataDetails");

            migrationBuilder.DropColumn(
                name: "StructurBytes",
                table: "Material_MetallographicDataDetails");
        }
    }
}
