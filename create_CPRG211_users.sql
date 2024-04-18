/* ****************************************************************************
**									                                         **
**	Script Name:  Create_CPRG211_Users.sql		                             **
**	Purpose:  Create new user accounts (CPRG211)               **
**									                                         **
***************************************************************************  */

ALTER SESSION SET "_ORACLE_SCRIPT"=TRUE;

CREATE USER cprg211 IDENTIFIED BY password
DEFAULT TABLESPACE users
QUOTA UNLIMITED ON users;

GRANT connect, resource, dba TO cprg211;



