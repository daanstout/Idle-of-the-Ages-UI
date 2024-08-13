GDPC                �                                                                         P   res://.godot/exported/133200997/export-3070c538c03ee49b7677ff960a3f5195-main.scnP'      <      2���|˩m��(�>�    ,   res://.godot/global_script_class_cache.cfg   +             ��Р�8���8~$}P�    D   res://.godot/imported/icon.svg-218a8f2b3041327d8a5756f3a245f83b.ctexp            ：Qt�E�cO���    D   res://.godot/imported/tree.png-69531096db38d62943d1ca75fb81369f.ctex�      �      �B�nq�-�D
���       res://.godot/uid_cache.bin  �.      �       ,��C�5�ES? �~ʤ    8   res://Resources/Mods/IdleOfTheAgesGame/Assets/data.json              ���C�m�����c�P    @   res://Resources/Mods/IdleOfTheAgesGame/Assets/skills/mining.json        �      }�+p�=�>|�Z��    H   res://Resources/Mods/IdleOfTheAgesGame/Assets/skills/woodcutting.json   �      �      ��bé���H�����    H   res://Resources/Mods/IdleOfTheAgesGame/Assets/textures/tree.png.import  0      �       ��S��o����:��    4   res://Resources/Mods/IdleOfTheAgesGame/Manifest.json       ?       �P�����VI?�a       res://Scripts/Application.cs`             h�)ژ��@��ح\��@       res://icon.svg   +      �      k����X3Y���f       res://icon.svg.import   �&      �       r������\"F��U�.       res://main.tscn.remap   �*      a       �J�Sw� ������       res://project.binaryp/      c      ���o}�5�Na��H��            {
    "$schema": "../../Idle-of-the-Ages.wiki/JsonSchemas/ModData/data.json",
    "namespace": "IdleOfTheAgesGame",
    "skills": [
        {
            "id": "mining",
            "name": "Mining",
            "skill_category": "IdleOfTheAgesGame:generating",
            "thumbnail": "IdleOfTheAgesGame:tree",
            "translation_key": "Mining",
            "unlock_age": "IdleOfTheAgesGame:Stone_Age",
            "page_group": "IdleOfTheAgesGame:generating"
        }
    ],
    "pages": [
        {
            "id": "mining_page",
            "name": "Mining Page",
            "translation_key": "Mining",
            "sorting_order": {
                "after": "IdleOfTheAgesGame:woodcutting_page"
            },
            "thumbnail": "IdleOfTheAgesGame:tree",
            "page_type": "skill",
            "target_id": "IdleOfTheAgesGame:mining",
            "page_group": "IdleOfTheAgesGame:generating"
        }
    ]
}         {
    "$schema": "../../Idle-of-the-Ages.wiki/JsonSchemas/ModData/data.json",
    "namespace": "IdleOfTheAgesGame",
    "skills": [
        {
            "id": "woodcutting",
            "name": "Woodcutting",
            "skill_category": "IdleOfTheAgesGame:generating",
            "thumbnail": "IdleOfTheAgesGame:tree",
            "translation_key": "Woodcutting",
            "unlock_age": "IdleOfTheAgesGame:Stone_Age",
            "page_group": "IdleOfTheAgesGame:generating"
        }
    ],
    "pages": [
        {
            "id": "woodcutting_page",
            "name": "Woodcutting Page",
            "translation_key": "Woodcutting",
            "sorting_order": {
                "order": 0
            },
            "thumbnail": "IdleOfTheAgesGame:tree",
            "page_type": "skill",
            "target_id": "IdleOfTheAgesGame:woodcutting",
            "page_group": "IdleOfTheAgesGame:generating"
        }
    ],
    "items": [
        {
            "id": "logs",
            "name": "Logs",
            "translation_key": "Logs",
            "thumbnail": "IdleOfTheAgesGame:Tree",
            "sorting_order": {
                "order": 0
            },
            "sell_price": 5,
            "category": "logs woodcutting",
            "description": "Logs_Description",
            "type": "logs",
            "required_for_completion": true
        },
        {
            "id": "oak_logs",
            "name": "Oak Logs",
            "translation_key": "Logs_Oak",
            "thumbnail": "IdleOfTheAgesGame:Tree",
            "sorting_order": {
                "after": "IdleOfTheAgesGame:logs"
            },
            "sell_price": 10,
            "category": "logs woodcutting",
            "description": "Logs_Oak_Description",
            "type": "logs",
            "required_for_completion": true
        }
    ],
    "actions": [
        {
            "skill_id": "IdleOfTheAgesGame:woodcutting",
            "actions": [
                {
                    "id": "woodcutting:oak",
                    "name": "Woodcutting Oak",
                    "translation_key": "Woodcutting_Oak",
                    "thumbnail": "IdleOfTheAgesGame:tree",
                    "base_duration": 1.0,
                    "base_xp": 5,
                    "base_expertise": 5,
                    "base_expertise_pool": 3,
                    "required_level": 1
                }
            ]
        }
    ],
    "loot_tables": [
        {
            "target_type": "skill",
            "target_id": "IdleOfTheAgesGame:woodcutting",
            "loot_entries": [
                {
                    "item_id": "IdleOfTheAgesGame:logs",
                    "guaranteed": "true",
                    "base_amount": 1
                }
            ]
        },
        {
            "target_type": "action",
            "target_id": "IdleOfTheAgesGame:woodcutting:oak",
            "loot_entries": [
                {
                    "item_id": "IdleOfTheAgesGame:oak_logs",
                    "guaranteed": "true",
                    "base_amount": 1
                }
            ]
        }
    ]
}  GST2   2   2      ����               2 2        n  RIFFf  WEBPVP8LZ  /1@ �ڶM�ٿ:۶m+�m;�m۶J۶m��.�}�e|e�D���}~�4�B�!M��j}������)-� -4�'<�V����Yr�h�����i�i�e5�'��C��_	j�O�b�5H@�Y��0�����b%��?�6�Rt0@_��I��Gr��Iࢠ�r����o�s�`��2�i`�f#W�T�|,\�&b��*z�ь���@8FP]0V3Q��=O�W����G)�ej)�ܣ�:�.��ä�P�[����b���K�Z���-O���׽�$�T�ݧ�=^
���v� 쫬S8� 2FS���?/(���6��\���V          [remap]

importer="texture"
type="CompressedTexture2D"
uid="uid://cughdlubwey2n"
path="res://.godot/imported/tree.png-69531096db38d62943d1ca75fb81369f.ctex"
metadata={
"vram_texture": false
}
                ﻿{
    "$schema": "../Idle-of-the-Ages.wiki/JsonSchemas/ModData/data.json",
    "namespace": "IdleOfTheAgesGame",
    "skills": [
        {
            "id": "woodcutting",
            "name": "Woodcutting",
            "translation_key": "Woodcutting",
            "thumbnail": "IdleOfTheAgesGame:tree",
            "sorting_order": {
                "order": 0
            },
            "skill_category": "IdleOfTheAgesGame:generating"
        },
        {
            "id": "mining",
            "name": "Mining",
            "translation_key": "Mining",
            "thumbnail": "IdleOfTheAgesGame:tree",
            "sorting_order": {
                "after": "IdleOfTheAgesGame:woodcutting"
            },
            "skill_category": "IdleOfTheAgesGame:generating"
        }
    ],
    "skill_categories": [
        {
            "id": "generating",
            "name": "Generating"
        }
    ],
    "page_groups": [
        {
            "id": "general",
            "name": "General",
            "translation_key": "General",
            "sorting_order": {
                "order": 0
            }
        },
        {
            "id": "generating",
            "name": "Generating",
            "translation_key": "Generating",
            "sorting_order": {
                "order": 10
            }
        }
    ],
    "sub_data": [
        [
            "Data",
            "mining.json"
        ],
        [
            "Data",
            "woodcutting.json"
        ]
    ]
}        {
  "namespace": "IdleOfTheAgesGame",
  "mod_class": "Mod"
} 
               GST2   �   �      ����               � �        �  RIFF�  WEBPVP8L�  /������!"2�H�m�m۬�}�p,��5xi�d�M���)3��$�V������3���$G�$2#�Z��v{Z�lێ=W�~� �����d�vF���h���ڋ��F����1��ڶ�i�엵���bVff3/���Vff���Ҿ%���qd���m�J�}����t�"<�,���`B �m���]ILb�����Cp�F�D�=���c*��XA6���$
2#�E.@$���A.T�p )��#L��;Ev9	Б )��D)�f(qA�r�3A�,#ѐA6��npy:<ƨ�Ӱ����dK���|��m�v�N�>��n�e�(�	>����ٍ!x��y�:��9��4�C���#�Ka���9�i]9m��h�{Bb�k@�t��:s����¼@>&�r� ��w�GA����ը>�l�;��:�
�wT���]�i]zݥ~@o��>l�|�2�Ż}�:�S�;5�-�¸ߥW�vi�OA�x��Wwk�f��{�+�h�i�
4�˰^91��z�8�(��yޔ7֛�;0����^en2�2i�s�)3�E�f��Lt�YZ���f-�[u2}��^q����P��r��v��
�Dd��ݷ@��&���F2�%�XZ!�5�.s�:�!�Њ�Ǝ��(��e!m��E$IQ�=VX'�E1oܪì�v��47�Fы�K챂D�Z�#[1-�7�Js��!�W.3׹p���R�R�Ctb������y��lT ��Z�4�729f�Ј)w��T0Ĕ�ix�\�b�9�<%�#Ɩs�Z�O�mjX �qZ0W����E�Y�ڨD!�$G�v����BJ�f|pq8��5�g�o��9�l�?���Q˝+U�	>�7�K��z�t����n�H�+��FbQ9���3g-UCv���-�n�*���E��A�҂
�Dʶ� ��WA�d�j��+�5�Ȓ���"���n�U��^�����$G��WX+\^�"�h.���M�3�e.
����MX�K,�Jfѕ*N�^�o2��:ՙ�#o�e.
��p�"<W22ENd�4B�V4x0=حZ�y����\^�J��dg��_4�oW�d�ĭ:Q��7c�ڡ��
A>��E�q�e-��2�=Ϲkh���*���jh�?4�QK��y@'�����zu;<-��|�����Y٠m|�+ۡII+^���L5j+�QK]����I �y��[�����(}�*>+���$��A3�EPg�K{��_;�v�K@���U��� gO��g��F� ���gW� �#J$��U~��-��u���������N�@���2@1��Vs���Ŷ`����Dd$R�":$ x��@�t���+D�}� \F�|��h��>�B�����B#�*6��  ��:���< ���=�P!���G@0��a��N�D�'hX�׀ "5#�l"j߸��n������w@ K�@A3�c s`\���J2�@#�_ 8�����I1�&��EN � 3T�����MEp9N�@�B���?ϓb�C��� � ��+�����N-s�M�  ��k���yA 7 �%@��&��c��� �4�{� � �����"(�ԗ�� �t�!"��TJN�2�O~� fB�R3?�������`��@�f!zD��%|��Z��ʈX��Ǐ�^�b��#5� }ى`�u�S6�F�"'U�JB/!5�>ԫ�������/��;	��O�!z����@�/�'�F�D"#��h�a �׆\-������ Xf  @ �q�`��鎊��M��T�� ���0���}�x^�����.�s�l�>�.�O��J�d/F�ě|+^�3�BS����>2S����L�2ޣm�=�Έ���[��6>���TъÞ.<m�3^iжC���D5�抺�����wO"F�Qv�ږ�Po͕ʾ��"��B��כS�p�
��E1e�������*c�������v���%'ž��&=�Y�ް>1�/E������}�_��#��|������ФT7׉����u������>����0����緗?47�j�b^�7�ě�5�7�����|t�H�Ե�1#�~��>�̮�|/y�,ol�|o.��QJ rmϘO���:��n�ϯ�1�Z��ը�u9�A������Yg��a�\���x���l���(����L��a��q��%`�O6~1�9���d�O{�Vd��	��r\�՜Yd$�,�P'�~�|Z!�v{�N�`���T����3?DwD��X3l �����*����7l�h����	;�ߚ�;h���i�0�6	>��-�/�&}% %��8���=+��N�1�Ye��宠p�kb_����$P�i�5�]��:��Wb�����������ě|��[3l����`��# -���KQ�W�O��eǛ�"�7�Ƭ�љ�WZ�:|���є9�Y5�m7�����o������F^ߋ������������������Р��Ze�>�������������?H^����&=����~�?ڭ�>���Np�3��~���J�5jk�5!ˀ�"�aM��Z%�-,�QU⃳����m����:�#��������<�o�����ۇ���ˇ/�u�S9��������ٲG}��?~<�]��?>��u��9��_7=}�����~����jN���2�%>�K�C�T���"������Ģ~$�Cc�J�I�s�? wڻU���ə��KJ7����+U%��$x�6
�$0�T����E45������G���U7�3��Z��󴘶�L�������^	dW{q����d�lQ-��u.�:{�������Q��_'�X*�e�:�7��.1�#���(� �k����E�Q��=�	�:e[����u��	�*�PF%*"+B��QKc˪�:Y��ـĘ��ʴ�b�1�������\w����n���l镲��l��i#����!WĶ��L}rեm|�{�\�<mۇ�B�HQ���m�����x�a�j9.�cRD�@��fi9O�.e�@�+�4�<�������v4�[���#bD�j��W����֢4�[>.�c�1-�R�����N�v��[�O�>��v�e�66$����P
�HQ��9���r�	5FO� �<���1f����kH���e�;����ˆB�1C���j@��qdK|
����4ŧ�f�Q��+�     [remap]

importer="texture"
type="CompressedTexture2D"
uid="uid://ii1uaer3pccs"
path="res://.godot/imported/icon.svg-218a8f2b3041327d8a5756f3a245f83b.ctex"
metadata={
"vram_texture": false
}
 RSRC                    PackedScene            ��������                                                  resource_local_to_scene    resource_name 	   _bundled    script       Script    res://Scripts/Application.cs ��������      local://PackedScene_8cdlg          PackedScene          	         names "   	      Main    script    Node2D    Label    offset_left    offset_top    offset_right    offset_bottom    text    	   variants                     �D    ��C    �D     �C      Test       node_count             nodes        ��������       ����                            ����                                           conn_count              conns               node_paths              editable_instances              version             RSRC    [remap]

path="res://.godot/exported/133200997/export-3070c538c03ee49b7677ff960a3f5195-main.scn"
               list=Array[Dictionary]([])
     <svg height="128" width="128" xmlns="http://www.w3.org/2000/svg"><rect x="2" y="2" width="124" height="124" rx="14" fill="#363d52" stroke="#212532" stroke-width="4"/><g transform="scale(.101) translate(122 122)"><g fill="#fff"><path d="M105 673v33q407 354 814 0v-33z"/><path d="m105 673 152 14q12 1 15 14l4 67 132 10 8-61q2-11 15-15h162q13 4 15 15l8 61 132-10 4-67q3-13 15-14l152-14V427q30-39 56-81-35-59-83-108-43 20-82 47-40-37-88-64 7-51 8-102-59-28-123-42-26 43-46 89-49-7-98 0-20-46-46-89-64 14-123 42 1 51 8 102-48 27-88 64-39-27-82-47-48 49-83 108 26 42 56 81zm0 33v39c0 276 813 276 814 0v-39l-134 12-5 69q-2 10-14 13l-162 11q-12 0-16-11l-10-65H446l-10 65q-4 11-16 11l-162-11q-12-3-14-13l-5-69z" fill="#478cbf"/><path d="M483 600c0 34 58 34 58 0v-86c0-34-58-34-58 0z"/><circle cx="725" cy="526" r="90"/><circle cx="299" cy="526" r="90"/></g><g fill="#414042"><circle cx="307" cy="532" r="60"/><circle cx="717" cy="532" r="60"/></g></g></svg>
              #��d�J�U?   res://Resources/Mods/IdleOfTheAgesGame/Assets/textures/tree.png6/��K   res://icon.svgI�3����U   res://main.tscn            ECFG      _custom_features         dotnet     application/config/name         Idle Of The Ages   application/run/main_scene         res://main.tscn    application/config/features,   "         4.2    C#     Forward Plus       application/config/icon         res://icon.svg     dotnet/project/assembly_name         Idle Of The Ages             