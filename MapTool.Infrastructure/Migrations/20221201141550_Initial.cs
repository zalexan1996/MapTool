using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapTool.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimatedTiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Uniquely identifies this row.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, defaultValue: ""),
                    AnimationSpeed = table.Column<int>(type: "int", nullable: false, defaultValue: 1000),
                    AnimationDelay = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimatedTiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Uniquely identifies this row.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, defaultValue: ""),
                    Author = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    VersionString = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Uniquely identifies this row.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, defaultValue: ""),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maps_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Palettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Uniquely identifies this row.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, defaultValue: ""),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palettes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Palettes_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prefabs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Uniquely identifies this row.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, defaultValue: ""),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prefabs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tilesheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Uniquely identifies this row.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, defaultValue: ""),
                    AssetReference = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tilesheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tilesheets_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Uniquely identifies this row.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentTilesheetId = table.Column<int>(type: "int", nullable: false),
                    StartX = table.Column<int>(type: "int", nullable: false),
                    StartY = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    TilesheetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tile_Tilesheets_ParentTilesheetId",
                        column: x => x.ParentTilesheetId,
                        principalTable: "Tilesheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tile_Tilesheets_TilesheetId",
                        column: x => x.TilesheetId,
                        principalTable: "Tilesheets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnimatedTileTile",
                columns: table => new
                {
                    AnimatedTileId = table.Column<int>(type: "int", nullable: false),
                    TilesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimatedTileTile", x => new { x.AnimatedTileId, x.TilesId });
                    table.ForeignKey(
                        name: "FK_AnimatedTileTile_AnimatedTiles_AnimatedTileId",
                        column: x => x.AnimatedTileId,
                        principalTable: "AnimatedTiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimatedTileTile_Tile_TilesId",
                        column: x => x.TilesId,
                        principalTable: "Tile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MapBridgeTile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Uniquely identifies this row."),
                    DestinationMapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapBridgeTile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapBridgeTile_Maps_DestinationMapId",
                        column: x => x.DestinationMapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapBridgeTile_Tile_Id",
                        column: x => x.Id,
                        principalTable: "Tile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaletteTile",
                columns: table => new
                {
                    PaletteId = table.Column<int>(type: "int", nullable: false),
                    TilesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaletteTile", x => new { x.PaletteId, x.TilesId });
                    table.ForeignKey(
                        name: "FK_PaletteTile_Palettes_PaletteId",
                        column: x => x.PaletteId,
                        principalTable: "Palettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaletteTile_Tile_TilesId",
                        column: x => x.TilesId,
                        principalTable: "Tile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpawnerTile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Uniquely identifies this row."),
                    AssetReference = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpawnerTile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpawnerTile_Tile_Id",
                        column: x => x.Id,
                        principalTable: "Tile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TilePlacements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Uniquely identifies this row.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TileId = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Opacity = table.Column<float>(type: "real", nullable: false, defaultValue: 1f),
                    VisibleInGame = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalDataJson = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false, defaultValue: ""),
                    MapId = table.Column<int>(type: "int", nullable: true),
                    PrefabId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TilePlacements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TilePlacements_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TilePlacements_Prefabs_PrefabId",
                        column: x => x.PrefabId,
                        principalTable: "Prefabs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TilePlacements_Tile_TileId",
                        column: x => x.TileId,
                        principalTable: "Tile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Uniquely identifies this row.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, defaultValue: ""),
                    TilePlacementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_TilePlacements_TilePlacementId",
                        column: x => x.TilePlacementId,
                        principalTable: "TilePlacements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MapTag",
                columns: table => new
                {
                    MapId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapTag", x => new { x.MapId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_MapTag_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MapTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrefabTag",
                columns: table => new
                {
                    PrefabId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrefabTag", x => new { x.PrefabId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PrefabTag_Prefabs_PrefabId",
                        column: x => x.PrefabId,
                        principalTable: "Prefabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrefabTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimatedTileTile_TilesId",
                table: "AnimatedTileTile",
                column: "TilesId");

            migrationBuilder.CreateIndex(
                name: "IX_MapBridgeTile_DestinationMapId",
                table: "MapBridgeTile",
                column: "DestinationMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_ProjectId",
                table: "Maps",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MapTag_TagsId",
                table: "MapTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Palettes_ProjectId",
                table: "Palettes",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PaletteTile_TilesId",
                table: "PaletteTile",
                column: "TilesId");

            migrationBuilder.CreateIndex(
                name: "IX_Prefabs_ProjectId",
                table: "Prefabs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PrefabTag_TagsId",
                table: "PrefabTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TilePlacementId",
                table: "Tags",
                column: "TilePlacementId");

            migrationBuilder.CreateIndex(
                name: "IX_Tile_ParentTilesheetId",
                table: "Tile",
                column: "ParentTilesheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Tile_TilesheetId",
                table: "Tile",
                column: "TilesheetId");

            migrationBuilder.CreateIndex(
                name: "IX_TilePlacements_MapId",
                table: "TilePlacements",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_TilePlacements_PrefabId",
                table: "TilePlacements",
                column: "PrefabId");

            migrationBuilder.CreateIndex(
                name: "IX_TilePlacements_TileId",
                table: "TilePlacements",
                column: "TileId");

            migrationBuilder.CreateIndex(
                name: "IX_Tilesheets_ProjectId",
                table: "Tilesheets",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimatedTileTile");

            migrationBuilder.DropTable(
                name: "MapBridgeTile");

            migrationBuilder.DropTable(
                name: "MapTag");

            migrationBuilder.DropTable(
                name: "PaletteTile");

            migrationBuilder.DropTable(
                name: "PrefabTag");

            migrationBuilder.DropTable(
                name: "SpawnerTile");

            migrationBuilder.DropTable(
                name: "AnimatedTiles");

            migrationBuilder.DropTable(
                name: "Palettes");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "TilePlacements");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Prefabs");

            migrationBuilder.DropTable(
                name: "Tile");

            migrationBuilder.DropTable(
                name: "Tilesheets");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
