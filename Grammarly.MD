## VKScript грамматики

### Переменные
 - `name_def_stmt <NodeBase>` = `var_multi_stmt` `var_stmt`
 - `var_stmt <VarNode>` = `"var" identifier "=" expr`
 - `var_multi_stmt <MultiVarNode>` = `"var" identifier [ { "," identifier } ] ":" type` |

### Значимые литералы
 - `identifier`  = `[a-zA-Z_][0-9a-zA-Z_]*`
 - `string <StringNode>` = `"([^"\\]|\\[^"]|(?<!\\)\\")*" | @"([^"]|"")*"`

### Операторы
 - `unary_op` = `"-" | "!"`
 - `binary_op` = `"|" | "&" | "^" | "&&" | "||" | "^^" | "==" | ">" | "<" | "<=" | ">=" | "+" | "-" | "*" | "/" | "%"`

### Литералы
 - `literal <NodeBase>` = `unit | null | bool | string`
 - `unit <UnitNode>` = `"()"`
 - `null <NullNode>` = `"null"`
 - `bool <BoolNode>` = `"true" | "false"`

### Структуры линейного контроля
 - `if_line <IfNode>` = `if_header line_stmt [ "else" line_stmt ]`
 - `while_line <IfNode>` = `while_header line_stmt`
 - `do_while_line <IfNode>` = `do_while_header line_stmt`

### Заголовки
 - `if_header <IfNode>` = `"if" line_expr "then"`
 - `while_header <WhileNode>` = `"while" line_expr "do"`
 - `do_while_header <DoWhileNode>` = `"do" line_expr "while"`

### Присвоение
 - `set_stmt <NodeBase>` = `set_id_stmt | set_stmbr_stmt | set_any_stmt`
 - `set_id_stmt <SetIdentifierNode>` = `identifier assignment_op expr`
 - `set_stmbr_stmt <SetMemberNode>` = `type "::" identifier assignment_op expr`
 - `set_any_stmt <NodeBase>` = `lvalue_expr assignment_op expr`
 - `assignment_op` = `[ binary_op ] "="`

### Блоки
 - `block <CodeBlockNode>` = `local_stmt_list | local_stmt`
 - `local_stmt_list <~NodeBase>` = `INDENT local_stmt { NL local_stmt } DEDENT`
 - `local_stmt <NodeBase>` = `name_def_stmt | set_stmt | expr`

### lvalues
- `lvalue_expr <NodeBase>` = `lvalue_name_expr | lvalue_paren_expr`
- `lvalue_name_expr <NodeBase>` = `lvalue_name { accessor }`
- `lvalue_paren_expr <NodeBase>` = `paren_expr accessor { accessor }`
- `lvalue_name <NodeBase>` = `lvalue_stmbr_expr | lvalue_id_expr`
- `lvalue_stmbr_expr <GetMemberNode>` = `type "::" identifier`
- `lvalue_id_expr <GetIdentifierNode>` = `identifier`

### Корень выражения
- `expr <NodeBase>` = `block_expr | line_expr`

### Аксессоры
- `get_expr <NodeBase>` = `atom { accessor }`
- `get_id_expr <GetIdentifierNode>` = `identifier [ type_args ]`
- `get_stmbr_expr <GetMemberNode>` = `type "::" identifier [ type_args ]`
- `accessor <NodeBase>` = `accessor_idx | accessor_mbr`
- `accessor_idx <GetIndexNode>` = `"[" line_expr "]"`
- `accessor_mbr <GetMemberNode>` = `"." identifier [ type_args ]`

### Блок управления структурами
- `block_expr <NodeBase>` = `if_block | while_block | for_block | using_block | try_stmt | match_block | new_block_expr | invoke_block_expr | lambda_block_expr`
- `if_block <IfNode>` = `if_header block [ "else" block ]`
- `while_block <WhileNode>` = `while_header block`
- `for_block <ForNode>` = `for_header block`
- `using_block <UsingNode>` = `using_header block`
- `try_stmt <TryNode>` = `"try" block catch_stmt_list [ finally_stmt ]`
- `catch_stmt_list <~CatchNode`   `              = catch_stmt { catch_stmt }`
- `catch_stmt <CatchNode>` = `"catch" [ identifier ":" type ] block`
- `finally_stmt <CodeBlockNode>` = `"finally" block`
- `lambda_block_expr <LambdaNode>` = `[ fun_args ] "->" block`

### Блочные инициализаторы
- `new_block_expr <NodeBase>` = `"new" ( new_tuple_block | new_array_block | new_list_block | new_dict_block | new_object_block )`
- `new_tuple_block <NewTupleNode>` = `"(" init_expr_block ")"`
- `new_list_block <NewListNode>` = `"[" "[" init_expr_block "]" "]"`
- `new_array_block <NewArrayNode>` = `"[" init_expr_block "]"`
- `new_dict_block <NewDictionaryNode>` = `"{" init_dict_expr_block "}"`
- `init_expr_block <~NodeBase>` = `INDENT line_expr { NL line_expr } DEDENT`
- `init_expr_dict_block` = `INDENT init_dict_expr { NL init_dict_expr } DEDENT`
- `init_dict_expr` = `line_expr "=>" line_expr`
- `new_object_block <NewObjectNode>` = `type invoke_block_args`

### Блочные вызовы
- `invoke_block_expr` = `line_expr { invoke_pass }`
- `invoke_pass` = `"|>" identifier [ type_args ] ( lambda_line_expr | invoke_block_args | invoke_line_args )`
- `invoke_block_args <~NodeBase>` = `INDENT { invoke_block_arg } DEDENT`
- `invoke_block_arg <NodeBase>` = `"<|" ( ref_arg | expr )`
- `invoke_line_args <~NodeBase>` = `{ invoke_line_arg }`
- `invoke_line_arg <NodeBase>` = `ref_arg | get_expr`
- `ref_arg <NodeBase>` = `"ref" lvalue_expr | "(" "ref" lvalue_expr ")"`

### Линейные выражения
 - `line_stmt <NodeBase>` = `set_stmt | line_expr`
 - `line_expr <NodeBase>` = `if_line | while_line | for_line | using_line | throw_stmt | new_object_expr | typeop_expr | line_typecheck_expr`
 - `typeop_expr <NodeBase>` = `default_expr | typeof_expr`
 - `default_expr <DefaultOperatorNode>` = `"default" type`
 - `typeof_expr <TypeofOperatorNode>` = `"typeof" type`
 - `line_typecheck_expr <NodeBase>` = `line_op_expr [ typecheck_op_expr ]`
 - `line_op_expr <NodeBase>` = `[ unary_op ] line_base_expr { binary_op line_base_expr }`
 - `typecheck_op_expr <NodeBase>` = `"as" type | "is" type`
 - `line_base_expr <NodeBase>` = `line_invoke_base_expr | get_expr`
 - `line_invoke_base_expr <NodeBase>` = `get_expr [ invoke_line_args ]`
 - `atom <NodeBase>` = `literal | get_stmbr_expr | get_id_expr | new_collection_expr | paren_expr`
 - `paren_expr <NodeBase>` = `"(" ( line_expr | lambda_line_expr ) ")"`
 - `lambda_line_expr <LambdaNode>` = `[ fun_args ] "->" line_stmt`

### Инициализаторы строк
- `new_object_expr <NodeBase>` = `"new" ( new_objarray_line | new_object_line )`
- `new_collection_expr <NodeBase>` = `"new" ( new_tuple_line | new_list_line | new_array_line | new_dict_line )`
- `new_tuple_line <NewTupleNode>` = `"(" init_expr_line ")"`
- `new_list_line <NewListNode>` = `"[" "[" init_expr_line "]" "]"`
- `new_array_line <NewArrayNode>` = `"[" init_expr_line "]"`
- `new_dict_line <NewDictionaryNode>` = `"{" init_dict_expr_line "}"`
- `new_objarray_line <NewObjectArrayNode> ` = `type "[" line_expr "]"`
- `new_object_line <NewObjectNode>` = `type [ invoke_line_args ]`
- `init_expr_line <~NodeBase>` = `line_expr { ";" line_expr }`
- `init_expr_dict_line <~NodeBase>` = `init_dict_expr { ";" init_dict_expr }`
