﻿using Bootstrap.Admin.Blazor.Models;
using Bootstrap.Security;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;

namespace Bootstrap.Admin.Blazor.Pages.Admin
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Dicts
    {
        private IEnumerable<SelectedItem>? Defines { get; set; }

        private IEnumerable<SelectedItem>? EditDefines { get; set; }


        private IEnumerable<SelectedItem>? LookUp { get; set; }

        private ITableSearchModel? DictsSearchModel { get; set; } = new DictsSearchModel();

        /// <summary>
        /// 
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Defines = new List<SelectedItem>()
            {
                new SelectedItem("2","全部"){ Active = true},
                new SelectedItem("0","系统使用"),
                new SelectedItem("1","自定义"),
            };

            EditDefines = new List<SelectedItem>()
            {
                new SelectedItem("0","系统使用"),
                new SelectedItem("1","自定义"),
            };

            LookUp = EditDefines;
        }

        private Task<(IEnumerable<BootstrapDict>, int)> OnQueryAsyncCallback(QueryPageOptions options)
        {
            var items = DataAccess.DictHelper.RetrieveDicts();
            var total = items.Count();

            // 处理高级搜索
            if (options.Searchs.Any())
            {
                items = items.Where(options.Searchs.GetFilterFunc<BootstrapDict>());
            }
            else
            {
                // 处理 SearchText 模糊搜索
                if (!string.IsNullOrEmpty(options.SearchText))
                {
                    items = items.Where(item => (item.Name?.Contains(options.SearchText) ?? false)
                        || (item.Category?.Contains(options.SearchText) ?? false));
                }
            }

            if (!string.IsNullOrEmpty(options.SortName))
            {
                items = items.Sort(options.SortName, options.SortOrder);
            }

            if (options.Filters.Any())
            {
                var aa = options.Filters.GetFilterFunc<BootstrapDict>();
                items = items.Where(options.Filters.GetFilterFunc<BootstrapDict>());
            }
            return Task.FromResult((items, total));
        }

        private Task<bool> OnDeleteAsyncCallback(IEnumerable<BootstrapDict> dicts)
        {
            var ids = dicts.Select(s => s.Id);
#nullable disable
            return Task.FromResult(DataAccess.DictHelper.Delete(ids));
#nullable restore
        }

        private Task<bool> OnAddOrUpdateAsyncCallback(BootstrapDict dicts, ItemChangedType changedType)
        {
            if (ItemChangedType.Add == changedType)
            {
                return Task.FromResult(DataAccess.DictHelper.Save(dicts));
            }
            else
            {
                return Task.FromResult(DataAccess.DictHelper.Save(dicts));
            }
        }
    }
}
