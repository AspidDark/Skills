CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE public.file_entity (
    id uuid NOT NULL,
    path character varying(1000) NOT NULL,
    create_date timestamp with time zone NOT NULL,
    edit_date timestamp with time zone NOT NULL,
    owner_id uuid NOT NULL,
    is_deleted integer NOT NULL,
    CONSTRAINT "PK_file_entity" PRIMARY KEY (id)
);

CREATE TABLE public.caharacter (
    id uuid NOT NULL,
    priority integer NOT NULL,
    build_name character varying(500) NOT NULL,
    starting_date date NOT NULL,
    story character varying(1000) NULL,
    photo_id uuid NULL,
    photo_id1 uuid NULL,
    create_date timestamp with time zone NOT NULL,
    edit_date timestamp with time zone NOT NULL,
    owner_id uuid NOT NULL,
    is_deleted integer NOT NULL,
    CONSTRAINT "PK_caharacter" PRIMARY KEY (id),
    CONSTRAINT "FK_caharacter_file_entity_photo_id1" FOREIGN KEY (photo_id1) REFERENCES public.file_entity (id)
);

CREATE TABLE public.skill (
    id uuid NOT NULL,
    priority integer NOT NULL,
    skill_name character varying(100) NOT NULL,
    level integer NOT NULL,
    "CahracterId" uuid NOT NULL,
    image_id uuid NULL,
    image_id1 uuid NULL,
    is_main integer NOT NULL,
    create_date timestamp with time zone NOT NULL,
    edit_date timestamp with time zone NOT NULL,
    owner_id uuid NOT NULL,
    is_deleted integer NOT NULL,
    CONSTRAINT "PK_skill" PRIMARY KEY (id),
    CONSTRAINT "FK_skill_caharacter_CahracterId" FOREIGN KEY ("CahracterId") REFERENCES public.caharacter (id) ON DELETE CASCADE,
    CONSTRAINT "FK_skill_file_entity_image_id1" FOREIGN KEY (image_id1) REFERENCES public.file_entity (id)
);

CREATE INDEX "IX_caharacter_photo_id1" ON public.caharacter (photo_id1);

CREATE INDEX "IX_skill_CahracterId" ON public.skill ("CahracterId");

CREATE INDEX "IX_skill_image_id1" ON public.skill (image_id1);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230306203343_Init', '7.0.3');

COMMIT;

