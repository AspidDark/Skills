INSERT INTO public.character_skill(
	id, priority, skill_name, level, "CharacterId", "SkillId", is_main, create_date, edit_date, owner_id, is_deleted)
	VALUES (gen_random_uuid (), 0, null, 0, '33334d2e-3d80-4e29-b6b5-ecb427e7293f', 'bcbd93f7-3041-483f-9232-8d9a83933f3a', 1, NOW(), NOW(), '32314d2e-3d80-4e29-b6b5-ecb427e7293f', 0);