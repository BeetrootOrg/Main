CREATE TABLE [dbo].[Orders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Flash] [varchar](20) NULL,
	[Customer] [varchar](60) NULL,
	[Ord] [varchar](25) NULL,
	[Steel] [varchar](60) NULL,
	[Surface] [varchar](60) NULL,
	[Thickness] [float] NULL,
	[Qty] [int] NULL,
	[Dimension1] [float] NULL,
	[Dimension2] [float] NULL,
	[Note] [text] NULL,
	[Manager] [varchar](60) NULL,
	[Operator] [varchar](60) NULL,
	[Modified] [datetime] NULL,
	[Bending] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]