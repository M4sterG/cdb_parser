// #include "main.h"

// #define STEP 100;

// char **get_names(char *, int *);

// int main()
// {
// 	char *strfile = "list.txt";

// 	FILE *pfile;
// 	struct stat st = {0};
// 	FILE *log = fopen("log.txt", "w+");
// 	FILE *out;
// 	FILE *descr;
// 	size_t fsize;

// 	char **file_names;

// 	int i = 0, j = 0, y = 0;
// 	int count;
// 	char dest[50] = {""};
// 	char descr_out[50] = {"_descr"};
// 	char sub[2][20] = {"./MV/JSON/", "./TW/JSON/"};
// 	file_names = get_names(strfile, &count);

// 	char *data = {NULL};
// 	int nofkeys = 0;
// 	int sblock_size = 0;
// 	int *entry_sizes = NULL;
// 	int dblock_size = 0;
// 	int ddblock_size = 0;
// 	int offset = 4;

// 	char *value = NULL;
// 	int temp = 0;
// 	char flag = '\0';
// 	char fname[50];

// 	int charsToDelete = 4;
// 	int pos;

// 	for (i = 0; i < count - 1; i++)
// 	{
// 		for (y = 0; y < 2; y++)
// 		{
// 			memset(fname, 0, sizeof(fname));
// 			strcpy(dest, sub[y]);
// 			strncat(dest, file_names[i], strlen(file_names[i]) - 4);
// 			strcat(dest, ".json");
// 			printf("Opening %s\n", file_names[i]);
// 			if (y == 0)
// 			{

// 				strcpy(fname, "MV/");
// 			}
// 			else
// 			{
// 				strncpy(fname, "TW/", 3);
// 			}

// 			strcat(fname, file_names[i]);

// 			pfile = fopen(fname, "rb");
// 			if (pfile == NULL)
// 			{
// 				perror("");
// 				continue;
// 			}

// 			out = fopen(dest, "wb");
// 			memset(dest, 0, sizeof(dest));
// 			strcpy(dest, sub[y]);
// 			strncat(dest, file_names[i], strlen(file_names[i]) - 4);
// 			strcat(dest, descr_out);
// 			strcat(dest, ".json");
// 			descr = fopen(dest, "wb");
// 			if (out == NULL)
// 			{
// 				perror("");
// 				continue;
// 			}

// 			dblock_size = 0;
// 			ddblock_size = 0;
// 			offset = 4;
// 			fsize = 0;
// 			stat(fname, &st);
// 			fsize = st.st_size;

// 			if (y == 0)
// 			{
// 				printf("File size MV: %d\n", (int)fsize);
// 				if (fsize == 0)
// 				{
// 					fprintf(log, "File MV/%s emtpty, skipping\n", file_names[i]);
// 					memset(dest, 0, sizeof(dest[y]));
// 					continue;
// 				}
// 			}
// 			else
// 			{
// 				printf("File size TW: %d\n", (int)fsize);
// 				if (fsize == 0)
// 				{
// 					fprintf(log, "File MV/%s emtpty, skipping\n", file_names[i]);
// 					memset(dest, 0, sizeof(dest[y]));
// 					continue;
// 				}
// 			}

// 			data = malloc(fsize + 1);
// 			memset(data, 0x0, fsize + 1);
// 			fread(data, fsize, 1, pfile);
// 			memcpy(&nofkeys, &data[0], sizeof(int));

// 			sblock_size = nofkeys * 30;
// 			entry_sizes = (int *)malloc(nofkeys * 4);

// 			fprintf(log, "Found %d keys in %s\n", nofkeys, file_names[i]);

// 			char keys[nofkeys][30];

// 			for (j = 0; j < nofkeys; j++, offset += 30)
// 			{
// 				strcpy(keys[j], &data[offset]);
// 			}

// 			for (j = 0; j < nofkeys; j++, offset += 4)
// 			{
// 				memcpy(&entry_sizes[j], &data[offset], sizeof(int));
// 				dblock_size += entry_sizes[j];
// 			}
// 			fprintf(descr, "{\n");
// 			for (j = 0; j < nofkeys; j++)
// 			{
// 				fprintf(log, "%s\t", keys[j]);
// 				fprintf(log, "length : %d \n", entry_sizes[j]);
// 				fprintf(descr, "\"%s\":%d,\n", keys[j], entry_sizes[j]);

// 			}
// 			fprintf(descr, "\"file_name\":\"%s\"\n}", fname);
// 			fclose(descr);
// 			fprintf(log, "Data block size : %d\n", dblock_size);

// 			if (sblock_size + dblock_size + 4 == fsize)
// 			{
// 				if (y == 0)
// 					fprintf(log, "File MV/%s emtpty, skipping\n", file_names[i]);
// 				else
// 					fprintf(log, "File TW/%s emtpty, skipping\n", file_names[i]);
// 				fclose(out);
// 				fclose(pfile);
// 				free(data);
// 				out = NULL;
// 				pfile = NULL;
// 				offset = 0;
// 				continue;
// 			}

// 			fprintf(out, "{\n");
// 			while (offset < fsize)
// 			{
// 				for (j = 0; j < nofkeys && offset < fsize; j++)
// 				{
// 					if (entry_sizes[j] == 1)
// 					{
// 						value = (char *)malloc(20);
// 						memcpy(&flag, &data[offset], entry_sizes[j]);
// 						if (flag == 1)
// 							sprintf(value, "%s", "true");
// 						else
// 							sprintf(value, "%s", "false");

// 						if (j != nofkeys - 1)
// 							fprintf(out, "\t\"%s\" : %s,\n", keys[j], value);
// 						else
// 							fprintf(out, "\t\"%s\" : %s\n},\n{\n", keys[j], value);
// 					}
// 					else if (entry_sizes[j] == 4)
// 					{
// 						value = (char *)malloc(20);
// 						memcpy(&temp, &data[offset], entry_sizes[j]);
// 						sprintf(value, "%d", temp);
// 						if (j != nofkeys - 1)
// 							fprintf(out, "\t\"%s\" : %s,\n", keys[j], value);
// 						else
// 							fprintf(out, "\t\"%s\" : %s\n},\n{\n", keys[j], value);
// 					}
// 					else
// 					{
// 						value = (char *)malloc(entry_sizes[j] + 1);
// 						strncpy(value, &data[offset], entry_sizes[j]);
// 						value[entry_sizes[j]] = '\0';
// 						if (j != nofkeys - 1)
// 							fprintf(out, "\t\"%s\" : \"%s\",\n", keys[j], value);
// 						else
// 							fprintf(out, "\t\"%s\" : \"%s\"\n},\n{\n", keys[j], value);
// 					}
// 					offset += entry_sizes[j];
// 					free(value);
// 				}
// 			}
// 			temp = 0;
// 			offset = 0;

// 			fseeko(out, -charsToDelete, SEEK_END);
// 			pos = ftello(out);
// 			ftruncate(fileno(out), pos);
// 			fclose(out);
// 			out = NULL;
// 			fclose(pfile);
// 			pfile = NULL;

// 			if (y == 0)
// 				printf("Closing MV/%s\n", file_names[i]);
// 			else
// 				printf("Closing TW/%s\n", file_names[i]);

// 			memset(dest, 0, sizeof(dest));
// 		}
// 	}
// 	fclose(log);
// 	printf("Script ended successfully, press any key to continue...\n");
// 	getchar();
// 	return 0;
// }

// char **get_names(char *name, int *lenght)
// {
// 	char **ret;
// 	FILE *list = fopen(name, "r");
// 	int i = 0;
// 	int arrlen = STEP;

// 	if (list)
// 	{
// 		char **lines = (char **)malloc(arrlen * sizeof(char *));
// 		char buff[512];
// 		while (fgets(buff, sizeof(buff), list))
// 		{
// 			if (i == arrlen)
// 			{
// 				arrlen += STEP;
// 				char **nlines = (char **)realloc(lines, arrlen * sizeof(char *));
// 				if (nlines == NULL)
// 				{
// 					exit(1);
// 				}
// 				lines = nlines;
// 			}
// 			buff[strlen(buff) - 1] = '\0';
// 			int len = strlen(buff);

// 			char *str = (char *)malloc((len + 1) * sizeof(char));
// 			strcpy(str, buff);

// 			lines[i] = str;
// 			i++;
// 		}
// 		ret = lines;
// 	}
// 	else
// 		ret = NULL;
// 	*lenght = i;

// 	return ret;
// }